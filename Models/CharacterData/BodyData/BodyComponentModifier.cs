using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class BodyComponentModifier : NullableXmlAttribute
{
    private string AttributeName { get; }

    public BodyComponentModifier(XElement parent, string attributeName) : base(parent)
    {
        AttributeName = attributeName;
    }
    
    protected override XAttribute CreateNode()
    {
        var attribute = new XAttribute(AttributeName, true);
        Parent.Add(attribute);
        return attribute;
    }
}