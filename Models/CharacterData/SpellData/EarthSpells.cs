using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class EarthSpells : ElementalSpells
{

    private static SpellTier[] SlamSpellTiers { get; } =
    [
        new("Unowned", "SLAM_UNOWNED"), new("Base", "SLAM"),
        new("Ground Shake", "SLAM_1"), new("Aftershock", "SLAM_2"),
        new("Earthquake", "SLAM_3")
    ];

    private static SpellTier[] TelekineticShowerSpellTiers { get; } =
    [
        // Yes, that is how telekinetic is spelt in the save file
        new("Unowned", "TELEKENETIC_SHOWER_UNOWNED"),
        new("Base", "TELEKENETIC_SHOWER"),
        new("Mind Over Matter", "TELEKENETIC_SHOWER_1"),
        new("Precision Strikes", "TELEKENETIC_SHOWER_2"),
        new("Unseen Force", "TELEKENETIC_SHOWER_3")
    ];

    private static SpellTier[] StoneShellSpellTiers { get; } =
    [
        new("Unowned", "STONE_SHELL_UNOWNED"), new("Base", "STONE_SHELL"),
        new("Shifting Sands", "STONE_SHELL_1"),
        new("Hardened Carapace", "STONE_SHELL_2"),
        new("Explosive Finish", "STONE_SHELL_3")
    ];

    private static SpellTier[] ElementalEarthSpellTiers { get; } =
    [
        new("Unowned", "ELEMENTAL_EARTH_UNOWNED"),
        new("Base", "ELEMENTAL_EARTH"),
        new("Rolling Stone", "ELEMENTAL_EARTH_1"),
        new("Hardening", "ELEMENTAL_EARTH_2"),
        new("Servant of Earth", "ELEMENTAL_EARTH_3A"),
        new("Binding of Earth", "ELEMENTAL_EARTH_3B")
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