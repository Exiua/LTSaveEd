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
    public XmlDate DateOfBirth { get; } = new(coreNode);
    public XmlAttribute<string> JobHistory { get; } = new(coreNode.GetChildsAttributeNode("history"));
    public XmlAttribute<string> SexualOrientation { get; } = new(coreNode.GetChildsAttributeNode("sexualOrientation"));
    public XmlAttribute<float> Obedience { get; } = new(coreNode.GetChildsAttributeNode("obedience"));

    public XmlAttribute<string> GenderIdentity { get; } = new(coreNode.GetChildsAttributeNode("genderIdentity"));
    public XmlAttribute<int> PerkPoints { get; } = new(coreNode.GetChildsAttributeNode("perkPoints"));
    public XmlAttribute<float> Health { get; } = new(coreNode.GetChildsAttributeNode("health"));
    public XmlAttribute<float> Mana { get; } = new(coreNode.GetChildsAttributeNode("mana"));
}