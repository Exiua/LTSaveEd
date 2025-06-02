using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor;

public class ColorTagsElement : NullableXmlObject
{
    private XElement? TagsNode => (XElement?)Node;
    
    public ColorTagsElement(XElement parent) : base(parent)
    {
        var tags = parent.Elements("tags").FirstOrDefault();
        if (tags is not null)
        {
            Initialize(tags);
        }
    }

    protected override XObject CreateNode()
    {
        var tags = new XElement("tags");
        Parent.Add(tags); // Probably should move child assignment up to the calling method
        return tags;
    }

    private int GetTagCount()
    {
        return TagsNode?.Elements("tag").Count() ?? 0;
    }

    private static XElement CreateColorTagNode(ColorTag tag)
    {
        return new XElement("tag", tag.GetValue());
    }

    private XElement? GetTagNode(ColorTag tag)
    {
        return TagsNode?.Elements("tag").FirstOrDefault(t => t.Value == tag.GetValue());
    }
    
    public void AddTag(ColorTag tag)
    {
        var tagNode = CreateColorTagNode(tag);
        Exists = true;
        if (GetTagNode(tag) is not null)
        {
            return; // Tag already exists, no need to add it again
        }
        
        TagsNode?.Add(tagNode);
    }
    
    public void RemoveTag(ColorTag tag)
    {
        var tagNode = GetTagNode(tag);
        tagNode?.Remove();
        if (GetTagCount() == 0)
        {
            Exists = false;
        }
    }
    
    public bool HasTag(ColorTag tag)
    {
        return GetTagNode(tag) is not null;
    }
}