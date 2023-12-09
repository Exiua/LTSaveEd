using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class XmlAttribute<T>
{
    private readonly XAttribute _attribute;

    public XmlAttribute(XAttribute attribute)
    {
        _attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));

        // Validate the type at construction
        if (typeof(T) != typeof(int) && typeof(T) != typeof(float) && typeof(T) != typeof(bool) && typeof(T) != typeof(string))
        {
            throw new ArgumentException("Invalid type. Only int, float, bool, and string are supported.");
        }
    }

    public T Value
    {
        get
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)int.Parse(_attribute.Value);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)float.Parse(_attribute.Value);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)bool.Parse(_attribute.Value);
            }
            return (T)(object)_attribute.Value;
        }
        set => _attribute.Value = value?.ToString() ?? throw new InvalidOperationException();
    }
}