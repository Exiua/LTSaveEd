using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using LTSaveEd.Utility;

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
                return (T)(object)TypeHelper.ParseInt(_element.Value);
            }
            if (typeof(T) == typeof(float))
            {
                return (T)(object)TypeHelper.ParseFloat(_element.Value);
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)TypeHelper.ParseBool(_element.Value);
            }
            return (T)(object)_element.Value;
        }
        set => _element.Value = GetValueAsString(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string GetValueAsString(T value)
    {
        return value switch
        {
            bool boolValue => boolValue.ToString().ToLower(),
            _ => value?.ToString() ?? throw new InvalidOperationException("Value cannot be null.")
        };
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