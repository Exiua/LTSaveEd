using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class WaterSpells : ElementalSpells
{
    private SpellTier[] IceShardSpellTiers { get; } =
    [
        new("Unowned", "ICE_SHARD_UNOWNED"), new("Base", "ICE_SHARD"),
        new("Freezing Fog", "ICE_SHARD_1"), new("Cold Snap", "ICE_SHARD_2"),
        new("Deep Freeze", "ICE_SHARD_3")
    ];

    private SpellTier[] RainCloudSpellTiers { get; } =
    [
        new("Unowned", "RAIN_CLOUD_UNOWNED"), new("Base", "RAIN_CLOUD"),
        new("Deep Chill", "RAIN_CLOUD_1"), new("Downpour", "RAIN_CLOUD_2"),
        new("Cloud Burst", "RAIN_CLOUD_3")
    ];

    private SpellTier[] SoothingWatersSpellTiers { get; } =
    [
        new("Unowned", "SOOTHING_WATERS_UNOWNED"),
        new("Base", "SOOTHING_WATERS"),
        new("Arcane Springs", "SOOTHING_WATERS_1"),
        new("Rejuvenation", "SOOTHING_WATERS_2"),
        new("Bouncing Orbs", "SOOTHING_WATERS_3")
    ];

    private SpellTier[] ElementalWaterSpellTiers { get; } =
    [
        new("Unowned", "ELEMENTAL_WATER_UNOWNED"),
        new("Base", "ELEMENTAL_WATER"),
        new("Crashing Waves", "ELEMENTAL_WATER_1"),
        new("Calm Waters", "ELEMENTAL_WATER_2"),
        new("Servant of Water", "ELEMENTAL_WATER_3A"),
        new("Binding of Water", "ELEMENTAL_WATER_3B")
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