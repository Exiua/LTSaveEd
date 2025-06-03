using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor.Xml.EnumXml;

public class RarityElement(XElement element) : XmlEnum<XElement, Rarity>(element)
{
    public override Rarity Value
    {
        get => RarityExtensions.FromValue(Element.Value);
        set => Element.Value = value.GetValue();
    }
}