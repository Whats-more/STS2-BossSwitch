using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Debug;
using MegaCrit.Sts2.Core.Entities;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Entities.Rngs;
using MegaCrit.Sts2.Core.Events; // 确保引用 EventOption
using MegaCrit.Sts2.Core.Extensions;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Map;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.Models.Relics; // 引用 Neow
using MegaCrit.Sts2.Core.Random;         // 引用 Rng 类型

namespace BossSwitch.Patches;

public static class BossSwitchOptionPatch
{
    internal static void Apply(Harmony harmony)
    {
        MethodInfo generateInitialOptions = AccessTools.Method(
            typeof(Neow),
            "GenerateInitialOptions",
            new Type[0]);

        harmony.Patch(generateInitialOptions,
            postfix: new HarmonyMethod(typeof(BossSwitchOptionPatch).GetMethod(
                nameof(GenerateInitialOptionsPostfix), BindingFlags.Static | BindingFlags.NonPublic)));
    }

    private static void GenerateInitialOptionsPostfix(Neow __instance, ref IReadOnlyList<EventOption> __result)
    {
        List<EventOption> options = __result.ToList();
        if (options.Count <= 1) return; // skipping the case count == 1 is to avoid replacing the only option of Neow in custom modes "Draft" and "Sealed Deck", since that replacement will leave the player without a starter deck

        Rng rng = __instance.Owner?.RunState.Rng.UpFront;

        if (rng == null) return;

        const float chanceToInclude = 0.35f;
        bool includeNewOption = rng.NextFloat() < chanceToInclude;

        if (!includeNewOption)
            return; // 
        
        int replaceIndex = rng.NextInt(0, options.Count);
        options[replaceIndex] = CreateBonusOption(__instance, rng);

        __result = options;
    }

    private static EventOption CreateBonusOption(Neow neow, Rng rng)
    {
        return new EventOption(
            neow,
            () => ShowRandomThreeOptions(neow, rng),
            new LocString("events", "BOSS_SWITCH.title"),
            new LocString("events", "BOSS_SWITCH.description"),
            "BOSS_SWITCH",
            Array.Empty<IHoverTip>());
    }

    private static async Task ShowRandomThreeOptions(Neow neow, Rng rng)
    {
        PropertyInfo prop = neow.Owner?.RunState.GetType().GetProperty("Acts", BindingFlags.Public | BindingFlags.Instance);
        List<ActModel> acts = (List<ActModel>)prop?.GetValue(neow.Owner?.RunState);

        List<AncientEventModel> validAncients = AncientRelicDatabase.Ancients.Where(ancient => acts?.Where(act => act.Ancient == ancient).Count() == 0).ToList();
        
        List<AncientEventModel> randomThreeAncients = validAncients.UnstableShuffle(rng).Take(3).ToList();
        List<RelicModel> randomThreeRelics = new List<RelicModel>();
        
        foreach (AncientEventModel ancient in randomThreeAncients)
        {
            HashSet<ModelId> relicIds = AncientRelicDatabase.AncientToRelicIds[ancient.Id].Except([ModelDb.Relic<TouchOfOrobas>().Id]).ToHashSet(); // since the starter relic is already lost
            // Log.Info($"{ancient.Id} has {relicIds.Count} relics.");
            if (relicIds.Count == 0) continue;
            ModelId selectedId = relicIds.ElementAt(rng.NextInt(relicIds.Count));
            // Log.Info($"chosen relic: {selectedId.ToString()}");
            RelicModel relic = ModelDb.GetById<RelicModel>(selectedId)?.ToMutable();
            randomThreeRelics.Add(relic);
        }

        
        List<EventOption> relicOptions = randomThreeRelics.Select(relic =>
            EventOption.FromRelic(relic, neow, () => ObtainRelicAndFinish(neow, relic), $"YOURMOD_NEOW_ANCIENT_PAGE.options.{relic.Id.Entry}")
        ).ToList();
        
        Traverse.Create(neow).Method("SetEventState",
            new LocString("events", "BOSS_SWITCH_PAGE.description"),
            relicOptions).GetValue();
        
    }

    private static async Task ObtainRelicAndFinish(Neow neow, RelicModel relic)
    {
        RelicModel starter = neow.Owner?.Relics.FirstOrDefault(r => r.Rarity == RelicRarity.Starter);
        if (starter != null)
        {
            await RelicCmd.Replace(starter, relic);
        }
        else if (neow.Owner != null)
        {
            await RelicCmd.Obtain(relic, neow.Owner);
        }
        
        Traverse.Create(neow).Method("SetEventFinished",
            new LocString("events", "BOSS_SWITCH_DONE.description")).GetValue();
    }
    
    
}