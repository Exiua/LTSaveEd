using System.Xml.Linq;
using LTSaveEd.Models.ModEditor.Enums;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class DamageTypeElement(XCData element) : XmlEnum<XCData, DamageType>(element)
{
    public override DamageType Value
    {
        get => DamageTypeExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}