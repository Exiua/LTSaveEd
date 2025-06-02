using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.InventoryData.Clothes;

public class Clothing : InventoryElement
{
    public XmlAttribute<bool> EnchantmentKnown { get; }
    public XmlAttribute<bool> IsDirty { get; }
    public XmlElement<string>[] Colors { get; }
    
    public Clothing(XElement clothingNode) : base(clothingNode)
    {
        EnchantmentKnown = new XmlAttribute<bool>(clothingNode.Attribute("enchantmentKnown")!);
        IsDirty = new XmlAttribute<bool>(clothingNode.Attribute("isDirty")!);
        var colorsNode = clothingNode.Element("colours")!;
        var colors = colorsNode.Elements().ToArray();
        Colors = new XmlElement<string>[colors.Length];
        for (var i = 0; i < colors.Length; i++)
        {
            var color = colors[i];
            Colors[i] = new XmlElement<string>(color);
        }
    }
}