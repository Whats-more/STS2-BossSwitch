using System.Collections.Generic;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.Models.Relics;

namespace BossSwitch.Patches;

public static class AncientRelicDatabase
{
    public static readonly List<AncientEventModel> Ancients = new List<AncientEventModel>()
    {
        ModelDb.Event<Neow>(),
        ModelDb.Event<Orobas>(),
        ModelDb.Event<Darv>(),
        ModelDb.Event<Nonupeipe>(),
        ModelDb.Event<Vakuu>(),
        ModelDb.Event<Tezcatara>(),
        ModelDb.Event<Tanx>(),
        ModelDb.Event<Pael>(),
    };
    
    public static readonly Dictionary<ModelId, HashSet<ModelId>> AncientToRelicIds = new Dictionary<ModelId, HashSet<ModelId>>
    {
        [ModelDb.Event<Neow>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<CursedPearl>().Id,
            ModelDb.Relic<DowsingRod>().Id,
            ModelDb.Relic<HeftyTablet>().Id,
            ModelDb.Relic<LargeCapsule>().Id,
            ModelDb.Relic<LeafyPoultice>().Id,
            ModelDb.Relic<NeowsBones>().Id,
            ModelDb.Relic<NeowsSacrifice>().Id,
            ModelDb.Relic<PrecariousShears>().Id,
            ModelDb.Relic<SilkenTress>().Id,
            ModelDb.Relic<SilverCrucible>().Id,
            ModelDb.Relic<ArcaneScroll>().Id,
            ModelDb.Relic<BoomingConch>().Id,
            ModelDb.Relic<FishingRod>().Id,
            ModelDb.Relic<GoldenPearl>().Id,
            ModelDb.Relic<Kaleidoscope>().Id,
            ModelDb.Relic<LeadPaperweight>().Id,
            ModelDb.Relic<LostCoffer>().Id,
            ModelDb.Relic<MassiveScroll>().Id,
            ModelDb.Relic<NeowsTorment>().Id,
            ModelDb.Relic<NewLeaf>().Id,
            ModelDb.Relic<PhialHolster>().Id,
            ModelDb.Relic<PreciseScissors>().Id,
            ModelDb.Relic<ScrollBoxes>().Id,
            ModelDb.Relic<WingedBoots>().Id,
            ModelDb.Relic<LavaRock>().Id,
            ModelDb.Relic<NeowsTalisman>().Id,
            ModelDb.Relic<NutritiousOyster>().Id,
            ModelDb.Relic<Pomander>().Id,
            ModelDb.Relic<SmallCapsule>().Id,
            ModelDb.Relic<StoneHumidifier>().Id,
        },
        [ModelDb.Event<Orobas>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<ElectricShrymp>().Id,
            ModelDb.Relic<GlassEye>().Id,
            ModelDb.Relic<AlchemicalCoffer>().Id,
            ModelDb.Relic<Driftwood>().Id,
            ModelDb.Relic<RadiantPearl>().Id,
            ModelDb.Relic<SandCastle>().Id,
            ModelDb.Relic<PrismaticGem>().Id,
            ModelDb.Relic<SeaGlass>().Id,
            ModelDb.Relic<TouchOfOrobas>().Id,
            ModelDb.Relic<ArchaicTooth>().Id,
        },
        [ModelDb.Event<Darv>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<Astrolabe>().Id,
            ModelDb.Relic<BlackStar>().Id,
            ModelDb.Relic<CallingBell>().Id,
            ModelDb.Relic<EmptyCage>().Id,
            ModelDb.Relic<PandorasBox>().Id,
            ModelDb.Relic<RunicPyramid>().Id,
            ModelDb.Relic<SneckoEye>().Id,
            ModelDb.Relic<Ectoplasm>().Id,
            ModelDb.Relic<Sozu>().Id,
            ModelDb.Relic<PhilosophersStone>().Id,
            ModelDb.Relic<VelvetChoker>().Id,
            ModelDb.Relic<DustyTome>().Id,
        },
        [ModelDb.Event<Nonupeipe>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<BlessedAntler>().Id,
            ModelDb.Relic<BrilliantScarf>().Id,
            ModelDb.Relic<DelicateFrond>().Id,
            ModelDb.Relic<DiamondDiadem>().Id,
            ModelDb.Relic<FurCoat>().Id,
            ModelDb.Relic<Glitter>().Id,
            ModelDb.Relic<JewelryBox>().Id,
            ModelDb.Relic<LoomingFruit>().Id,
            ModelDb.Relic<SignetRing>().Id,
            ModelDb.Relic<BeautifulBracelet>().Id,
        },
        [ModelDb.Event<Vakuu>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<BloodSoakedRose>().Id,
            ModelDb.Relic<WhisperingEarring>().Id,
            ModelDb.Relic<Fiddle>().Id,
            ModelDb.Relic<PreservedFog>().Id,
            ModelDb.Relic<SereTalon>().Id,
            ModelDb.Relic<DistinguishedCape>().Id,
            ModelDb.Relic<ChoicesParadox>().Id,
            ModelDb.Relic<MusicBox>().Id,
            ModelDb.Relic<LordsParasol>().Id,
            ModelDb.Relic<JeweledMask>().Id,
        },
        [ModelDb.Event<Tezcatara>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<VeryHotCocoa>().Id,
            ModelDb.Relic<YummyCookie>().Id,
            ModelDb.Relic<BiiigHug>().Id,
            ModelDb.Relic<Storybook>().Id,
            ModelDb.Relic<ToastyMittens>().Id,
            ModelDb.Relic<GoldenCompass>().Id,
            ModelDb.Relic<PumpkinCandle>().Id,
            ModelDb.Relic<ToyBox>().Id,
            ModelDb.Relic<SealOfGold>().Id,
            ModelDb.Relic<NutritiousSoup>().Id,
        },
        [ModelDb.Event<Tanx>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<Claws>().Id,
            ModelDb.Relic<Crossbow>().Id,
            ModelDb.Relic<IronClub>().Id,
            ModelDb.Relic<MeatCleaver>().Id,
            ModelDb.Relic<Sai>().Id,
            ModelDb.Relic<SpikedGauntlets>().Id,
            ModelDb.Relic<TanxsWhistle>().Id,
            ModelDb.Relic<ThrowingAxe>().Id,
            ModelDb.Relic<WarHammer>().Id,
            ModelDb.Relic<TriBoomerang>().Id,
        },
        [ModelDb.Event<Pael>().Id] = new HashSet<ModelId>
        {
            ModelDb.Relic<PaelsFlesh>().Id,
            ModelDb.Relic<PaelsHorn>().Id,
            ModelDb.Relic<PaelsTears>().Id,
            ModelDb.Relic<PaelsWing>().Id,
            ModelDb.Relic<PaelsEye>().Id,
            ModelDb.Relic<PaelsBlood>().Id,
            ModelDb.Relic<PaelsClaw>().Id,
            ModelDb.Relic<PaelsTooth>().Id,
            ModelDb.Relic<PaelsGrowth>().Id,
            ModelDb.Relic<PaelsLegion>().Id,
        },
    };

    public static HashSet<ModelId> GetRelicIds(AncientEventModel ancient)
    {
        return AncientToRelicIds.TryGetValue(ancient.Id, out HashSet<ModelId> ids) ? ids : new HashSet<ModelId>();
    }
}