using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.InventoryData;

public class Clothing : InventoryElement
{

    public XmlAttribute<bool> EnchantmentKnown { get; }
    public XmlAttribute<bool> IsDirty { get; }
    
    public Clothing(XElement clothingNode) : base(clothingNode)
    {
        EnchantmentKnown = new XmlAttribute<bool>(clothingNode.Attribute("enchantmentKnown")!);
        IsDirty = new XmlAttribute<bool>(clothingNode.Attribute("isDirty")!);
        var colors = clothingNode.Element("colours")!;
        // TODO: Support multiple colors for clothing
    }
}