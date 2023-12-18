using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class AirSpells : ElementalSpells
{
    private SpellTier[] PoisonVapoursSpellTiers { get; } =
    [
        new SpellTier("Unowned", "POISON_VAPOURS_UNOWNED"), new SpellTier("Base", "POISON_VAPOURS"),
        new SpellTier("Choking Haze", "POISON_VAPOURS_1"),
        new SpellTier("Arcane Sickness", "POISON_VAPOURS_2"),
        new SpellTier("Weakening Cloud", "POISON_VAPOURS_3")
    ];
    
    private SpellTier[] VacuumSpellTiers { get; } =
    [
        new SpellTier("Unowned", "VACUUM_UNOWNED"), new SpellTier("Base", "VACUUM"),
        new SpellTier("Secondary Voids", "VACUUM_1"), new SpellTier("Suction", "VACUUM_2"),
        new SpellTier("Total Void", "VACUUM_3")
    ];
    
    private SpellTier[] ProtectiveGustsSpellTiers { get; } =
    [
        new SpellTier("Unowned", "PROTECTIVE_GUSTS_UNOWNED"),
        new SpellTier("Base", "PROTECTIVE_GUSTS"),
        new SpellTier("Guiding Wind", "PROTECTIVE_GUSTS_1"),
        new SpellTier("Focused Blast", "PROTECTIVE_GUSTS_2"),
        new SpellTier("Lingering Presence", "PROTECTIVE_GUSTS_3")
    ];
    
    private SpellTier[] ElementalAirSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ELEMENTAL_AIR_UNOWNED"),
        new SpellTier("Base", "ELEMENTAL_AIR"),
        new SpellTier("Whirlwind", "ELEMENTAL_AIR_1"),
        new SpellTier("Vitalising Scents", "ELEMENTAL_AIR_2"),
        new SpellTier("Servant of Air", "ELEMENTAL_AIR_3A"),
        new SpellTier("Binding of Air", "ELEMENTAL_AIR_3B")
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