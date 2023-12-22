using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class ArcaneSpells : ElementalSpells
{
    private SpellTier[] ArcaneArousalSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ARCANE_AROUSAL_UNOWNED"),
        new SpellTier("Base", "ARCANE_AROUSAL"),
        new SpellTier("Overwhelming Lust", "ARCANE_AROUSAL_1"),
        new SpellTier("Lustful Distraction", "ARCANE_AROUSAL_2"),
        new SpellTier("Dirty Promises", "ARCANE_AROUSAL_3")
    ];

    private SpellTier[] TelepathicCommunicationSpellTiers { get; } =
    [
        new SpellTier("Unowned", "TELEPATHIC_COMMUNICATION_UNOWNED"),
        new SpellTier("Base", "TELEPATHIC_COMMUNICATION"),
        new SpellTier("Echoing Moans", "TELEPATHIC_COMMUNICATION_1"),
        new SpellTier("Projected Touch", "TELEPATHIC_COMMUNICATION_2"),
        new SpellTier("Power of Suggestion", "TELEPATHIC_COMMUNICATION_3")
    ];
    
    private SpellTier[] ArcaneCloudSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ARCANE_CLOUD_UNOWNED"), new SpellTier("Base", "ARCANE_CLOUD"),
        new SpellTier("Arcane Lightning", "ARCANE_CLOUD_1"),
        new SpellTier("Arcane Thunder", "ARCANE_CLOUD_2"),
        new SpellTier("Localized Storm", "ARCANE_CLOUD_3")
    ];

    private SpellTier[] CleanseSpellTiers { get; } =
    [
        new SpellTier("Unowned", "CLEANSE_UNOWNED"), new SpellTier("Base", "CLEANSE"),
        new SpellTier("Selective Cleansing", "CLEANSE_1"),
        new SpellTier("Arcane Duality", "CLEANSE_2"),
        new SpellTier("Arcane Will", "CLEANSE_3")
    ];

    private SpellTier[] StealSpellTiers { get; } =
    [
        new SpellTier("Unowned", "STEAL_UNOWNED"), new SpellTier("Base", "STEAL"),
        new SpellTier("Stripper", "STEAL_1"), new SpellTier("Disarm", "STEAL_2"),
        new SpellTier("Deep Reach", "STEAL_3A"), new SpellTier("Panty Snatcher", "STEAL_3B")
    ];


    private SpellTier[] TeleportSpellTiers { get; } =
    [
        new SpellTier("Unowned", "TELEPORT_UNOWNED"), new SpellTier("Base", "TELEPORT"),
        new SpellTier("Arcane Arrival", "TELEPORT_1"),
        new SpellTier("Mass Teleportation", "TELEPORT_2"),
        new SpellTier("Rebounding Teleportation", "TELEPORT_3")
    ];

    private SpellTier[] LilithsCommandSpellTiers { get; } =
    [
        new SpellTier("Unowned", "LILITHS_COMMAND_UNOWNED"),
        new SpellTier("Base", "LILITHS_COMMAND"),
        new SpellTier("Overpowering Presence", "LILITHS_COMMAND_1"),
        new SpellTier("Demonic Servants", "LILITHS_COMMAND_2"),
        new SpellTier("Ultimate Power", "LILITHS_COMMAND_3")
    ];

    private SpellTier[] ElementalArcaneSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ELEMENTAL_ARCANE_UNOWNED"), new SpellTier("Base", "ELEMENTAL_ARCANE"),
        new SpellTier("Lewd Encouragement", "ELEMENTAL_ARCANE_1"),
        new SpellTier("Caressing Touch", "ELEMENTAL_ARCANE_2"),
        new SpellTier("Servant of Arcane", "ELEMENTAL_ARCANE_3A"),
        new SpellTier("Binding of Arcane", "ELEMENTAL_ARCANE_3B")
    ];
    
    public Spell ArcaneArousal { get; }
    public Spell TelepathicCommunication { get; }
    public Spell ArcaneCloud { get; }
    public Spell Cleanse { get; }
    public Spell Steal { get; }
    public Spell Teleport { get; }
    public Spell LilithsCommand { get; }
    public Spell ArcaneElemental { get; }
    
    public ArcaneSpells(XElement knownSpellsNode, XElement spellUpgradesNode, XElement spellUpgradePointsNode) : base(knownSpellsNode, spellUpgradesNode)
    {
        ArcaneArousal = new Spell(ArcaneArousalSpellTiers, knownSpellsNode, spellUpgradesNode);
        TelepathicCommunication = new Spell(TelepathicCommunicationSpellTiers, knownSpellsNode, spellUpgradesNode);
        ArcaneCloud = new Spell(ArcaneCloudSpellTiers, knownSpellsNode, spellUpgradesNode);
        Cleanse = new Spell(CleanseSpellTiers, knownSpellsNode, spellUpgradesNode);
        Steal = new Spell(StealSpellTiers, knownSpellsNode, spellUpgradesNode);
        Teleport = new Spell(TeleportSpellTiers, knownSpellsNode, spellUpgradesNode);
        LilithsCommand = new Spell(LilithsCommandSpellTiers, knownSpellsNode, spellUpgradesNode);
        ArcaneElemental = new Spell(ElementalArcaneSpellTiers, knownSpellsNode, spellUpgradesNode);
        UpgradePoints = GetUpgradePointNode(spellUpgradePointsNode, "ARCANE");
    }
}