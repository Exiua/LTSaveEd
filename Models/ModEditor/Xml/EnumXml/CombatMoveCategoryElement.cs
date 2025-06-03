using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class CombatMoveCategoryElement(XElement element) : XmlEnum<XElement, CombatMoveCategory>(element)
{
    public override CombatMoveCategory Value
    {
        get => CombatMoveCategoryExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}