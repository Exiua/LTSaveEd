using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Relationship
{
    public string CharacterName { get; set; }
    public XmlAttribute<string> CharacterId { get; }
    public XmlAttribute<float> Value { get; }
    
    
    public Relationship(XElement relationshipNode, Dictionary<string, string> idNameLookup)
    {
        var idAttribute = relationshipNode.Attribute("character")!;
        CharacterName = idNameLookup[idAttribute.Value];
        CharacterId = new XmlAttribute<string>(idAttribute);
        Value = new XmlAttribute<float>(relationshipNode.Attribute("value")!);
    }

    public Relationship(XElement relationshipNode, string characterName)
    {
        CharacterName = characterName;
        CharacterId = new XmlAttribute<string>(relationshipNode.Attribute("character")!);
        Value = new XmlAttribute<float>(relationshipNode.Attribute("value")!);
    }
}