using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.InventoryData;

public class Item : InventoryElement
{

    public XmlAttribute<string> Color { get; }
    
    public Item(XElement itemNode) : base(itemNode)
    {
        Color = new XmlAttribute<string>(itemNode.Attribute("colour")!);
    }
}