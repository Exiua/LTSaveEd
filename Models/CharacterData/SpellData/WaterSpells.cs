﻿using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class WaterSpells : ElementalSpells
{
    private SpellTier[] IceShardSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ICE_SHARD_UNOWNED"), new SpellTier("Base", "ICE_SHARD"),
        new SpellTier("Freezing Fog", "ICE_SHARD_1"), new SpellTier("Cold Snap", "ICE_SHARD_2"),
        new SpellTier("Deep Freeze", "ICE_SHARD_3")
    ];

    private SpellTier[] RainCloudSpellTiers { get; } =
    [
        new SpellTier("Unowned", "RAIN_CLOUD_UNOWNED"), new SpellTier("Base", "RAIN_CLOUD"),
        new SpellTier("Deep Chill", "RAIN_CLOUD_1"), new SpellTier("Downpour", "RAIN_CLOUD_2"),
        new SpellTier("Cloud Burst", "RAIN_CLOUD_3")
    ];

    private SpellTier[] SoothingWatersSpellTiers { get; } =
    [
        new SpellTier("Unowned", "SOOTHING_WATERS_UNOWNED"),
        new SpellTier("Base", "SOOTHING_WATERS"),
        new SpellTier("Arcane Springs", "SOOTHING_WATERS_1"),
        new SpellTier("Rejuvenation", "SOOTHING_WATERS_2"),
        new SpellTier("Bouncing Orbs", "SOOTHING_WATERS_3")
    ];

    private SpellTier[] ElementalWaterSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ELEMENTAL_WATER_UNOWNED"),
        new SpellTier("Base", "ELEMENTAL_WATER"),
        new SpellTier("Crashing Waves", "ELEMENTAL_WATER_1"),
        new SpellTier("Calm Waters", "ELEMENTAL_WATER_2"),
        new SpellTier("Servant of Water", "ELEMENTAL_WATER_3A"),
        new SpellTier("Binding of Water", "ELEMENTAL_WATER_3B")
    ];
    
    public Spell IceShard { get; }
    public Spell RainCloud { get; }
    public Spell SoothingWaters { get; }
    public Spell WaterElemental { get; }
    public NullableSpell CleansingWaters { get; }
    public NullableSpell DeepClean { get; }

    public WaterSpells(XElement knownSpellsNode, XElement spellUpgradesNode, XElement spellUpgradePointsNode) : base(knownSpellsNode, spellUpgradesNode)
    {
        IceShard = new Spell(IceShardSpellTiers, knownSpellsNode, spellUpgradesNode);
        RainCloud = new Spell(RainCloudSpellTiers, knownSpellsNode, spellUpgradesNode);
        SoothingWaters= new Spell(SoothingWatersSpellTiers, knownSpellsNode, spellUpgradesNode);
        WaterElemental = new Spell(ElementalWaterSpellTiers, knownSpellsNode, spellUpgradesNode);
        CleansingWaters = new NullableSpell(spellUpgradesNode, "SOOTHING_WATERS_1_CLEAN");
        DeepClean = new NullableSpell(spellUpgradesNode, "SOOTHING_WATERS_2_CLEAN");
        UpgradePoints = GetUpgradePointNode(spellUpgradePointsNode, "WATER");

        var spellUpgrades = spellUpgradesNode.Elements();
        foreach (var spell in spellUpgrades)
        {
            var spellType = spell.GetAttributeValue<string>("type");
            if (!spellType.EndsWith("CLEAN"))
            {
                continue;
            }
            
            // SOOTHING_WATERS_2 < index: 16
            switch (spellType[16])
            {
                case '1':
                    CleansingWaters.Initialize(spell);
                    break;
                case '2':
                    DeepClean.Initialize(spell);
                    break;
                default:
                    Console.WriteLine($"Unknown Cleaning Spell Encountered: {spellType}");
                    break;
            }
        }
    }
}