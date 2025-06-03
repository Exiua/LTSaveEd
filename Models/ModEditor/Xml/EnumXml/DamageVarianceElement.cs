using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class DamageVarianceElement(XElement element) : XmlEnum<XElement, DamageVariance>(element)
{
    public override DamageVariance Value
    {
        get => DamageVarianceExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}