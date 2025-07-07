using System.Globalization;
using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.XmlData;

public class XmlCData<T>
{
    private readonly XCData _cdata;

    public T Value
    {
        get
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)TypeHelper.ParseInt(_cdata.Value);
            }

            if (typeof(T) == typeof(float))
            {
                return (T)(object)TypeHelper.ParseFloat(_cdata.Value);
            }

            if (typeof(T) == typeof(bool))
            {
                return (T)(object)TypeHelper.ParseBool(_cdata.Value);
            }

            return (T)(object)_cdata.Value;
        }
        set => _cdata.Value = value?.ToString() ?? throw new InvalidOperationException();
    }

    public XmlCData(XCData cdata)
    {
        _cdata = cdata;

        // Validate the type at construction
        if (typeof(T) != typeof(int) && typeof(T) != typeof(float) && typeof(T) != typeof(bool) &&
            typeof(T) != typeof(string))
        {
            throw new ArgumentException("Invalid type. Only int, float, bool, and string are supported.");
        }
    }
}