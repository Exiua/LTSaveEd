using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class PresetColorElement(XElement element) : XmlEnum<XElement, PresetColor>(element)
{
    public override PresetColor Value
    {
        get => PresetColorExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}