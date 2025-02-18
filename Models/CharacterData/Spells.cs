using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.SpellData;

namespace LTSaveEd.Models.CharacterData;

public class Spells
{
    public EarthSpells Earth { get; }
    public WaterSpells Water { get; }
    public FireSpells Fire { get; }
    public AirSpells Air { get; }
    public ArcaneSpells Arcane { get; }
    public MiscSpells Misc { get; }

    public Spells(XElement knownSpellsNode, XElement spellUpgradesNode, XElement spellUpgradePointsNode)
    {
        Earth = new EarthSpells(knownSpellsNode, spellUpgradesNode, spellUpgradePointsNode);
        Water = new WaterSpells(knownSpellsNode, spellUpgradesNode, spellUpgradePointsNode);
        Fire = new FireSpells(knownSpellsNode, spellUpgradesNode, spellUpgradePointsNode);
        Air = new AirSpells(knownSpellsNode, spellUpgradesNode, spellUpgradePointsNode);
        Arcane = new ArcaneSpells(knownSpellsNode, spellUpgradesNode, spellUpgradePointsNode);
        Misc = new MiscSpells(knownSpellsNode, spellUpgradesNode);
    }
}