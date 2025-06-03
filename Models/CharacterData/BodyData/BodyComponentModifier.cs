using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class BodyComponentModifier : NullableXmlObject
{
    private string AttributeName { get; }
    private string ModifierName { get; }

    public BodyComponentModifier(XElement parent, string attributeName, string modifierName = "mod") : base(parent)
    {
        AttributeName = attributeName;
        ModifierName = modifierName;
    }
    
    protected override XElement CreateNode()
    {
        var attribute = new XElement(ModifierName, AttributeName);
        Parent.Add(attribute);
        return attribute;
    }
}