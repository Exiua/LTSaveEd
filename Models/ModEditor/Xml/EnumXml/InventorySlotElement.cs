using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class InventorySlotElement(XElement element) : XmlEnum<XElement, InventorySlot>(element)
{
    public override InventorySlot Value
    {
        get => InventorySlotExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}