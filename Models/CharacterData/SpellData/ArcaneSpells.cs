using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class ArcaneSpells : ElementalSpells
{
    private SpellTier[] ArcaneArousalSpellTiers { get; } =
    [
        new("Unowned", "ARCANE_AROUSAL_UNOWNED"),
        new("Base", "ARCANE_AROUSAL"),
        new("Overwhelming Lust", "ARCANE_AROUSAL_1"),
        new("Lustful Distraction", "ARCANE_AROUSAL_2"),
        new("Dirty Promises", "ARCANE_AROUSAL_3")
    ];

    private SpellTier[] TelepathicCommunicationSpellTiers { get; } =
    [
        new("Unowned", "TELEPATHIC_COMMUNICATION_UNOWNED"),
        new("Base", "TELEPATHIC_COMMUNICATION"),
        new("Echoing Moans", "TELEPATHIC_COMMUNICATION_1"),
        new("Projected Touch", "TELEPATHIC_COMMUNICATION_2"),
        new("Power of Suggestion", "TELEPATHIC_COMMUNICATION_3")
    ];
    
    private SpellTier[] ArcaneCloudSpellTiers { get; } =
    [
        new("Unowned", "ARCANE_CLOUD_UNOWNED"), new("Base", "ARCANE_CLOUD"),
        new("Arcane Lightning", "ARCANE_CLOUD_1"),
        new("Arcane Thunder", "ARCANE_CLOUD_2"),
        new("Localized Storm", "ARCANE_CLOUD_3")
    ];

    private SpellTier[] CleanseSpellTiers { get; } =
    [
        new("Unowned", "CLEANSE_UNOWNED"), new("Base", "CLEANSE"),
        new("Selective Cleansing", "CLEANSE_1"),
        new("Arcane Duality", "CLEANSE_2"),
        new("Arcane Will", "CLEANSE_3")
    ];

    private SpellTier[] StealSpellTiers { get; } =
    [
        new("Unowned", "STEAL_UNOWNED"), new("Base", "STEAL"),
        new("Stripper", "STEAL_1"), new("Disarm", "STEAL_2"),
        new("Deep Reach", "STEAL_3A"), new("Panty Snatcher", "STEAL_3B")
    ];


    private SpellTier[] TeleportSpellTiers { get; } =
    [
        new("Unowned", "TELEPORT_UNOWNED"), new("Base", "TELEPORT"),
        new("Arcane Arrival", "TELEPORT_1"),
        new("Mass Teleportation", "TELEPORT_2"),
        new("Rebounding Teleportation", "TELEPORT_3")
    ];

    private SpellTier[] LilithsCommandSpellTiers { get; } =
    [
        new("Unowned", "LILITHS_COMMAND_UNOWNED"),
        new("Base", "LILITHS_COMMAND"),
        new("Overpowering Presence", "LILITHS_COMMAND_1"),
        new("Demonic Servants", "LILITHS_COMMAND_2"),
        new("Ultimate Power", "LILITHS_COMMAND_3")
    ];

    private SpellTier[] ElementalArcaneSpellTiers { get; } =
    [
        new("Unowned", "ELEMENTAL_ARCANE_UNOWNED"), new("Base", "ELEMENTAL_ARCANE"),
        new("Lewd Encouragement", "ELEMENTAL_ARCANE_1"),
        new("Caressing Touch", "ELEMENTAL_ARCANE_2"),
        new("Servant of Arcane", "ELEMENTAL_ARCANE_3A"),
        new("Binding of Arcane", "ELEMENTAL_ARCANE_3B")
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