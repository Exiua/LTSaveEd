using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class AirSpells : ElementalSpells
{
    private SpellTier[] PoisonVapoursSpellTiers { get; } =
    [
        new("Unowned", "POISON_VAPOURS_UNOWNED"), new("Base", "POISON_VAPOURS"),
        new("Choking Haze", "POISON_VAPOURS_1"),
        new("Arcane Sickness", "POISON_VAPOURS_2"),
        new("Weakening Cloud", "POISON_VAPOURS_3")
    ];
    
    private SpellTier[] VacuumSpellTiers { get; } =
    [
        new("Unowned", "VACUUM_UNOWNED"), new("Base", "VACUUM"),
        new("Secondary Voids", "VACUUM_1"), new("Suction", "VACUUM_2"),
        new("Total Void", "VACUUM_3")
    ];
    
    private SpellTier[] ProtectiveGustsSpellTiers { get; } =
    [
        new("Unowned", "PROTECTIVE_GUSTS_UNOWNED"),
        new("Base", "PROTECTIVE_GUSTS"),
        new("Guiding Wind", "PROTECTIVE_GUSTS_1"),
        new("Focused Blast", "PROTECTIVE_GUSTS_2"),
        new("Lingering Presence", "PROTECTIVE_GUSTS_3")
    ];
    
    private SpellTier[] ElementalAirSpellTiers { get; } =
    [
        new("Unowned", "ELEMENTAL_AIR_UNOWNED"),
        new("Base", "ELEMENTAL_AIR"),
        new("Whirlwind", "ELEMENTAL_AIR_1"),
        new("Vitalising Scents", "ELEMENTAL_AIR_2"),
        new("Servant of Air", "ELEMENTAL_AIR_3A"),
        new("Binding of Air", "ELEMENTAL_AIR_3B")
    ];

    public Spell PoisonVapours { get; }
    public Spell Vacuum { get; }
    public Spell ProtectiveGusts { get; }
    public Spell AirElemental { get; }
    
    public AirSpells(XElement knownSpellsNode, XElement spellUpgradesNode, XElement spellUpgradePointsNode) : base(knownSpellsNode, spellUpgradesNode)
    {
        PoisonVapours = new Spell(PoisonVapoursSpellTiers, knownSpellsNode, spellUpgradesNode);
        Vacuum = new Spell(VacuumSpellTiers, knownSpellsNode, spellUpgradesNode);
        ProtectiveGusts = new Spell(ProtectiveGustsSpellTiers, knownSpellsNode, spellUpgradesNode);
        AirElemental = new Spell(ElementalAirSpellTiers, knownSpellsNode, spellUpgradesNode);
        UpgradePoints = GetUpgradePointNode(spellUpgradePointsNode, "AIR");
    }
}