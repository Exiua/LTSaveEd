using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class Offsprings
{
    public List<Offspring> OffspringsList { get; } = [];
    private List<XElement> OffspringNodes { get; } = [];
    private readonly Func<string, XElement> _getCharacterNode;

    public int NumOffsprings => OffspringsList.Count;
    
    public Offsprings(IEnumerable<XElement> offspringNodes, Func<string, XElement> getCharacterNode)
    {
        _getCharacterNode = getCharacterNode;
        foreach (var offspringNode in offspringNodes)
        {
            var offspring = new Offspring(offspringNode);
            OffspringsList.Add(offspring);
            OffspringNodes.Add(offspringNode);
        }
    }

    public void RemoveOffspring(int index)
    {
        var offspring = OffspringsList[index];
        RemoveOffspringFromCharacterNode(offspring.Family.Mother.Id.Value, offspring.Id.Value);
        RemoveOffspringFromCharacterNode(offspring.Family.Father.Id.Value, offspring.Id.Value);
        OffspringsList.RemoveAt(index);
        OffspringNodes[index].Remove();
        OffspringNodes.RemoveAt(index);
    }

    public void RemoveAllOffsprings()
    {
        foreach (var offspring in OffspringsList)
        {
            RemoveOffspringFromCharacterNode(offspring.Family.Mother.Id.Value, offspring.Id.Value);
            RemoveOffspringFromCharacterNode(offspring.Family.Father.Id.Value, offspring.Id.Value);
        }
        
        foreach (var offspringNode in OffspringNodes)
        {
            offspringNode.Remove();
        }
        
        OffspringsList.Clear();
        OffspringNodes.Clear();
    }
    
    private void RemoveOffspringFromCharacterNode(string characterId, string offspringId){
        XElement characterNode;
        try {
            characterNode = _getCharacterNode(characterId);
        }
        catch (KeyNotFoundException){
            // Parent no longer exists
            return;
        }
        var pregnancyNode = characterNode.Element("pregnancy")!;
        string[] litterNodeNames = {"pregnantLitter", "birthedLitters", "littersFathered"};
        foreach (var nodeName in litterNodeNames)
        {
            var littersNode = pregnancyNode.Element(nodeName);
            if(littersNode is null){
                continue;
            }

            if(RemoveOffspringNodeFromLittersNode(littersNode, offspringId)){
                return;
            }
        }

        Console.WriteLine($"Offspring {{{offspringId}}} not found under character {{{characterId}}}");
    }

    private static bool RemoveOffspringNodeFromLittersNode(XElement littersNode, string offspringId){
        // Handles littersFathered, birthedLitters, and pregnantLitter nodes
        var litters = littersNode.Elements();
        foreach (var litter in litters)
        {
            var offspringList = litter.Element("offspringList")!;
            var offspringNodes = offspringList.Elements();
            foreach (var offspringNode in offspringNodes)
            {
                var offspringNodeId = offspringNode.GetAttributeValue<string>("id");
                if (offspringNodeId != offspringId)
                {
                    continue;
                }
                
                offspringNode.Remove();
                return true;
            }
        }
        return false;
    }
}