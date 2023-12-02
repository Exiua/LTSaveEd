using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class Core(XElement coreNode)
{
    public XmlAttribute<string> Id { get; } = new(coreNode.GetChildsAttributeNode("id"));
    public Name Name { get; } = new(coreNode.Element("name")!, coreNode.Element("surname")!);
    public XmlAttribute<string> Description { get; } = new(coreNode.GetChildsAttributeNode("description"));
    public XmlAttribute<int> Level { get; } = new(coreNode.GetChildsAttributeNode("level"));
    public XmlAttribute<int> Experience { get; } = new(coreNode.GetChildsAttributeNode("experience"));
    // public int Money { get; set; } // Part of Character Inventory
    public DateOfBirth DateOfBirth { get; } = new(coreNode);
    // TODO: Job History
    // TODO: Orientation
    public XmlAttribute<float> Obedience { get; } = new(coreNode.GetChildsAttributeNode("obedience"));
    // TODO: Gender Identity
    public XmlAttribute<int> PerkPoints { get; } = new(coreNode.GetChildsAttributeNode("perkPoints"));
    //public int EssenceCount { get; set; } // Part of Character Inventory
    public XmlAttribute<float> Health { get; } = new(coreNode.GetChildsAttributeNode("health"));
    public XmlAttribute<float> Mana { get; } = new(coreNode.GetChildsAttributeNode("mana"));
}