using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.InventoryData;

public abstract class InventoryElement
{
    protected readonly int MaxEffects = 100;
    
    public XmlAttribute<string> Id { get; }
    public XmlAttribute<string> Name { get; }
    public XmlAttribute<int> Count { get; }
    
    // TODO: Effects

    protected InventoryElement(XElement inventoryElementNode)
    {
        Id = new XmlAttribute<string>(inventoryElementNode.Attribute("id")!);
        var nameNode = inventoryElementNode.Attribute("name");  // Apparently, used items don't have a name attribute
        if (nameNode is null)
        {
            nameNode = new XAttribute("name", Id);
            inventoryElementNode.Add(nameNode);
            Name = new XmlAttribute<string>(nameNode);
        }
        else
        {
            Name = new XmlAttribute<string>(nameNode);
        }
        Count = new XmlAttribute<int>(inventoryElementNode.Attribute("count")!);
    }
}