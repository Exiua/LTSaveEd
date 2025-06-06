using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public abstract class NullableXmlObject(XElement parent)
{
    protected XElement Parent { get; } = parent;
    protected XObject? Node { get; set; }

    public bool Exists
    {
        get => Node is not null;
        set
        {
            if (value)
            {
                Node ??= CreateNode();
            }
            else
            {
                if (Node is null)
                {
                    return;
                }
                
                DeleteNode();
            }
        }
    }

    public void Initialize(XObject element)
    {
        Node = element;
    }

    protected abstract XObject CreateNode();

    private void DeleteNode()
    {
        switch (Node)
        {
            case XElement element:
                element.Remove();
                break;
            case XAttribute attribute:
                attribute.Remove();
                break;
            // TODO: Check if CData can be nullable on its own
            case XCData data:
                data.Parent!.Remove();
                break;
        }
        Node = null;
    }
}