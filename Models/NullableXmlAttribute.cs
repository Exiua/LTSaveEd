using System.Xml.Linq;

namespace LTSaveEd.Models;

public abstract class NullableXmlAttribute(XElement parent, XElement? element = null)
{
    private XElement Parent { get; } = parent;
    protected XElement? Element { get; set; } = element;

    public bool Exists
    {
        get => Element is not null;
        set
        {
            if (value)
            {
                Element ??= CreateElement();
            }
            else
            {
                if (Element is null)
                {
                    return;
                }
                
                DeleteElement();
                Element = null;
            }
        }
    }

    protected abstract XElement CreateElement();
    protected abstract void DeleteElement();
}