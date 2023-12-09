using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public abstract class NullableXmlAttribute(XElement parent)
{
    private XElement Parent { get; } = parent;
    protected XElement? Element { get; set; }

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
            }
        }
    }

    protected void Initialize(XElement element)
    {
        Element = element;
    }

    protected abstract XElement CreateElement();

    protected virtual void DeleteElement()
    {
        Element?.Remove();
        Element = null;
    }
}