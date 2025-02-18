using System.Xml.Linq;
using LTSaveEd.Models.CharacterData;

namespace LTSaveEd.Models;

public class Character(XContainer characterNode, Dictionary<string, string> idNameLookup)
{
    public Core Core { get; } = new(characterNode.Element("core")!);
    public Attributes Attributes { get; } = new(characterNode.Element("attributes")!);
    public Body Body { get; } = new(characterNode.Element("body")!);
    public Fetishes Fetishes { get; } = new(characterNode.Element("fetishes")!);
    public Perks Perks { get; } = new(characterNode.Element("perks")!);
    public Spells Spells { get; } = new(characterNode.Element("knownSpells")!, characterNode.Element("spellUpgrades")!, characterNode.Element("spellUpgradePoints")!);
    public Inventory Inventory { get; } = new(characterNode.Element("characterInventory")!);
    public Relationships Relationships { get; } = new(characterNode.Element("characterRelationships")!, idNameLookup);
    public Family Family { get; } = new(characterNode.Element("family")!);

    public bool IsPlayer => Core.Id.Value == "PlayerCharacter";

    public CharacterShortData Shorten()
    {
        var id = Core.Id.Value;
        var femininityValue = Body.BodyCore.Femininity.Value;
        var names = Core.Name;
        var subspecies = Body.BodyCore.SubspeciesOverride.Value;
        string femininity;
        string name;
        switch (femininityValue)
        {
            case < 20:
                femininity = "VERY_MASCULINE";
                name = names.Masculine.Value;
                break;
            case < 40:
                femininity = "MASCULINE";
                name = names.Masculine.Value;
                break;
            case < 60:
                femininity = "ANDROGYNOUS";
                name = names.Androgynous.Value;
                break;
            case < 80:
                femininity = "FEMININE";
                name = names.Feminine.Value;
                break;
            case >= 80:
                femininity = "VERY_FEMININE";
                name = names.Feminine.Value;
                break;
        }
        return new CharacterShortData(id, name, femininity, subspecies);
    }
}