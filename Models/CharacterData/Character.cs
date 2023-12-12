using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData;

public class Character(XElement characterNode)
{
    public Core Core { get; } = new(characterNode.Element("core")!);
    public Attributes Attributes { get; } = new(characterNode.Element("attributes")!);
    public Body Body { get; } = new(characterNode.Element("body")!);
    public Fetishes Fetishes { get; } = new(characterNode.Element("fetishes")!);
    public Perks Perks { get; } = new(characterNode.Element("perks")!);
    public Spells Spells { get; } = new(characterNode.Element("knownSpells")!, characterNode.Element("spellUpgrades")!, characterNode.Element("spellUpgradePoints")!);
    public Inventory Inventory { get; } = new(characterNode.Element("characterInventory")!);
    public Family Family { get; } = new(characterNode.Element("family")!);

    public bool IsPlayer => Core.Id.Value == "PlayerCharacter";
}