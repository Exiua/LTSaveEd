using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class EarthSpells : ElementalSpells
{

    private static SpellTier[] SlamSpellTiers { get; } =
    [
        new SpellTier("Unowned", "SLAM_UNOWNED"), new SpellTier("Base", "SLAM"),
        new SpellTier("Ground Shake", "SLAM_1"), new SpellTier("Aftershock", "SLAM_2"),
        new SpellTier("Earthquake", "SLAM_3")
    ];

    private static SpellTier[] TelekineticShowerSpellTiers { get; } =
    [
        // Yes, that is how telekinetic is spelt in the save file
        new SpellTier("Unowned", "TELEKENETIC_SHOWER_UNOWNED"),
        new SpellTier("Base", "TELEKENETIC_SHOWER"),
        new SpellTier("Mind Over Matter", "TELEKENETIC_SHOWER_1"),
        new SpellTier("Precision Strikes", "TELEKENETIC_SHOWER_2"),
        new SpellTier("Unseen Force", "TELEKENETIC_SHOWER_3")
    ];

    private static SpellTier[] StoneShellSpellTiers { get; } =
    [
        new SpellTier("Unowned", "STONE_SHELL_UNOWNED"), new SpellTier("Base", "STONE_SHELL"),
        new SpellTier("Shifting Sands", "STONE_SHELL_1"),
        new SpellTier("Hardened Carapace", "STONE_SHELL_2"),
        new SpellTier("Explosive Finish", "STONE_SHELL_3")
    ];

    private static SpellTier[] ElementalEarthSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ELEMENTAL_EARTH_UNOWNED"),
        new SpellTier("Base", "ELEMENTAL_EARTH"),
        new SpellTier("Rolling Stone", "ELEMENTAL_EARTH_1"),
        new SpellTier("Hardening", "ELEMENTAL_EARTH_2"),
        new SpellTier("Servant of Earth", "ELEMENTAL_EARTH_3A"),
        new SpellTier("Binding of Earth", "ELEMENTAL_EARTH_3B")
    ];

    public Spell Slam { get; }
    public Spell TelekineticShower { get; }
    public Spell StoneShell { get; }
    public Spell EarthElemental { get; }
    
    
    public EarthSpells(XElement knownSpellsNode, XElement spellUpgradesNode, XElement spellUpgradePointsNode) : base(knownSpellsNode, spellUpgradesNode)
    {
        Slam = new Spell(SlamSpellTiers, knownSpellsNode, spellUpgradesNode);
        TelekineticShower = new Spell(TelekineticShowerSpellTiers, knownSpellsNode, spellUpgradesNode);
        StoneShell = new Spell(StoneShellSpellTiers, knownSpellsNode, spellUpgradesNode);
        EarthElemental = new Spell(ElementalEarthSpellTiers, knownSpellsNode, spellUpgradesNode);
        UpgradePoints = GetUpgradePointNode(spellUpgradePointsNode, "EARTH");
    }
}