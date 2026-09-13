using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData;

public class Relationships
{
    public List<Relationship> RelationshipsData { get; } = [];
    
    private readonly List<XElement> _relationshipNodes = [];
    private readonly XElement _relationshipsNode;
    
    public Relationships(XElement relationshipsNode, Dictionary<string, string> idNameLookup)
    {
        _relationshipsNode = relationshipsNode;
        var relationships = relationshipsNode.Elements();
        foreach (var relationshipElement in relationships)
        {
            var relationship = Relationship.Lookup(relationshipElement, idNameLookup);
            // If the character ID in the relationship node does not exist in the idNameLookup, skip this relationship
            if (relationship is null)
            {
                continue;
            }
            
            RelationshipsData.Add(relationship);
            _relationshipNodes.Add(relationshipElement);
        }
    }

    public void RemoveRelationship(int index)
    {
        _relationshipNodes[index].Remove();
        _relationshipNodes.RemoveAt(index);
        RelationshipsData.RemoveAt(index);
    }

    public void AddRelationship(string characterName, string characterId)
    {
        if (RelationshipsData.Any(relationship => relationship.CharacterId.Value == characterId)) // Prevent duplicate relationship entries
        {
            return;
        }
        
        var relationshipElement = new XElement("relationship", new XAttribute("character", characterId), new XAttribute("value", 0));
        var relationship = Relationship.CreateNew(relationshipElement, characterName);
        _relationshipsNode.Add(relationshipElement);
        RelationshipsData.Add(relationship);
        _relationshipNodes.Add(relationshipElement);
    }
}