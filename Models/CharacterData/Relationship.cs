using System.Xml.Linq;
using LTSaveEd.Models.XmlData;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LTSaveEd.Models.CharacterData;

public class Relationship
{
    private static readonly ILogger Logger = Log.ForContext<Relationship>();
    
    public string CharacterName { get; set; }
    public XmlAttribute<string> CharacterId { get; private init; }
    public XmlAttribute<float> Value { get; private init; }

    private Relationship()
    {
        // This constructor should only be called by the Lookup and CreateNew static methods which will set the properties after creation.
        CharacterName = null!;
        CharacterId = null!;
        Value = null!;
    }
    
    public static Relationship? Lookup(XElement relationshipNode, Dictionary<string, string> idNameLookup)
    {
        var idAttribute = relationshipNode.Attribute("character")!;
        var characterName = idNameLookup.GetValueOrDefault(idAttribute.Value);
        if (characterName is null)
        {
            Logger.Warning("Character ID {CharacterId} not found in idNameLookup. Skipping relationship.", idAttribute.Value);
            return null;
        }
        
        return new Relationship
        {
            CharacterName = characterName,
            CharacterId = new XmlAttribute<string>(idAttribute),
            Value = new XmlAttribute<float>(relationshipNode.Attribute("value")!)
        };
    }
    
    public static Relationship CreateNew(XElement relationshipNode, string characterName)
    {
        var newRelationship = new Relationship
        {
            CharacterName = characterName,
            CharacterId = new XmlAttribute<string>(relationshipNode.Attribute("character")!),
            Value = new XmlAttribute<float>(relationshipNode.Attribute("value")!),
        };
        
        return newRelationship;
    }
}