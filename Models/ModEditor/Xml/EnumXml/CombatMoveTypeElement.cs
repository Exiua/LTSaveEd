using System.Xml.Linq;
using LTSaveEd.Models.ModEditor.Enums;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class CombatMoveTypeElement(XElement element) : XmlEnum<XElement, CombatMoveType>(element)
{
    public override CombatMoveType Value
    {
        get => CombatMoveTypeExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}