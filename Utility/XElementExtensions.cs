using System.Linq;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Utility;

public static class XElementExtensions
{
    public static XElement GetDescendantByName(this XElement parent, string tagName)
    {
        var tag = (from el in parent.Descendants(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFoundException(tagName);
        }
        return tag;
    }

    public static XElement GetChildByName(this XElement parent, string tagName)
    {
        var tag = (from el in parent.Elements(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFoundException(tagName);
        }
        
        return tag;
    }

    public static XAttribute GetAttributeByName(this XElement parent, string attributeName = "value")
    {
        var attribute = (from attr in parent.Attributes(attributeName) select attr).First();
        if (attribute is null)
        {
            throw new AttributeNotFoundException(attributeName);
        }

        return attribute;
    }

    public static string GetAttributeValueByName(this XElement parent, string attributeName = "value")
    {
        var attribute = (from attr in parent.Attributes(attributeName) select attr).First();
        if (attribute is null)
        {
            throw new AttributeNotFoundException(attributeName);
        }

        return attribute.Value;
    }

    public static XAttribute GetChildAttributeByName(this XElement parent, string childName, string attributeName = "value")
    {
        var child = parent.GetChildByName(childName);
        return child.GetAttributeByName(attributeName);
    }

    public static string GetChildAttributeValue(this XElement parent, string tagName, string attributeName = "value")
    {
        return parent.GetChildByName(tagName).GetAttributeByName(attributeName).Value;
    }

    public static XElement GetChildBySequence(this XElement parent, params string[] tagNames)
    {
        return tagNames.Aggregate(parent, (current, tag) => current.GetChildByName(tag));
    }
}