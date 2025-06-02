using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class XmlElement<T>
{
    private readonly XElement _element;
    
    public T Value
    {
        get
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)int.Parse(_element.Value);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)float.Parse(_element.Value);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)bool.Parse(_element.Value);
            }
            return (T)(object)_element.Value;
        }
        set => _element.Value = value?.ToString() ?? throw new InvalidOperationException();
    }

    public XmlElement(XElement element)
    {
        _element = element;
        
        // Validate the type at construction
        if (typeof(T) != typeof(int) && typeof(T) != typeof(float) && typeof(T) != typeof(bool) && typeof(T) != typeof(string))
        {
            throw new ArgumentException("Invalid type. Only int, float, bool, and string are supported.");
        }
    }
}