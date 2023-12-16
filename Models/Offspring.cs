using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.CharacterData;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models;

public class Offspring
{
    public XmlAttribute<string> Id { get; }
    public XmlAttribute<bool> FromPlayer { get; }
    public XmlAttribute<bool> Born { get; }
    public Name Name { get; }
    public Family Family { get; }
    
    public Offspring(XElement offspringSeedNode)
    {
        var dataNode = offspringSeedNode.Element("data")!;
        Id = new XmlAttribute<string>(dataNode.GetChildsAttributeNode("id"));
        FromPlayer = new XmlAttribute<bool>(dataNode.GetChildsAttributeNode("fromPlayer"));
        Born = new XmlAttribute<bool>(dataNode.GetChildsAttributeNode("born"));

        var nameNode = dataNode.Element("name")!;
        var surnameNode = dataNode.Element("surname")!;
        Name = new Name(nameNode, surnameNode);

        var familyNode = offspringSeedNode.Element("family")!;
        Family = new Family(familyNode);
    }
}