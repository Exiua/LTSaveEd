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
}