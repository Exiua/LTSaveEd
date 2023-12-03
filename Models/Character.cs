using System.Xml.Linq;

namespace LTSaveEd.Models;

public class Character(XElement characterNode)
{
    public Core Core { get; } = new(characterNode.Element("core")!);
    // public Body Body { get; } = new(characterNode.Element("body")!);
    public Inventory Inventory { get; } = new(characterNode.Element("characterInventory")!);
    public Attributes Attributes { get; } = new(characterNode.Element("attributes")!);
}