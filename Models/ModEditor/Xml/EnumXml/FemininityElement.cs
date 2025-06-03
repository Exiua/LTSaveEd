using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class FemininityElement(XElement element) : XmlEnum<XElement, Femininity>(element)
{
    public override Femininity Value
    {
        get => FemininityExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}