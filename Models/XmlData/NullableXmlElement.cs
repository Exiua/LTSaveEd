using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class NullableXmlElement<T>(XElement parent, string tagName) : NullableXmlObject(parent)
{
    public T? Value
    {
        get
        {
            if (Node is null)
            {
                return default;
            }
            
            var element = (XElement)Node;
            if (typeof(T) == typeof(int))
            {
                return (T)(object)int.Parse(element.Value);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)float.Parse(element.Value);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)bool.Parse(element.Value);
            }
            return (T)(object)element.Value;
        }
        set
        {
            if (value is null)
            {
                Exists = false;
                return;
            }
            
            Exists = true; // Guarantee that the node exists before setting the value
            var element = (XElement)Node!;
            element.Value = value.ToString() ?? throw new InvalidOperationException();
        }
    }

    protected override XElement CreateNode()
    {
        var element = new XElement(tagName);
        Parent.Add(element);
        return element;
    }
}