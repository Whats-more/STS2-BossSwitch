using System;
using System.Collections.Generic;
using System.Reflection;
using BaseLib.Config;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BossSwitch.Patches;
    
namespace BossSwitch
{
    [ModInitializer(nameof(Initialize))]
    public static class ModInitializer
    {
        public const string ModId = "boss-switch.whatsmore";

        public static void Initialize()
        {
            ModConfigRegistry.Register(ModId, new BossSwitchConfig());

            // Harmony.DEBUG = true;
            Harmony harmony = new Harmony(ModId); // 格式：模组ID.作者名
            BossSwitchOptionPatch.Apply(harmony);
        }
    }
}