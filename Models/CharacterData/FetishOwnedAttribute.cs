using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class FetishOwnedAttribute(XElement parent) : NullableXmlAttribute(parent)
{
    protected override XAttribute CreateNode()
    {
        var ownedAttribute =  new XAttribute("o", true);
        Parent.Add(ownedAttribute);
        return ownedAttribute;
    }
}