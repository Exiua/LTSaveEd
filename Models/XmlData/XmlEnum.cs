using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public abstract class XmlEnum<TElement, TEnum> where TElement : XObject where TEnum : Enum
{
    protected readonly TElement Element;

    public abstract TEnum Value { get; set; }

    protected XmlEnum(TElement element)
    {
        if (element is not XElement && element is not XCData)
        {
            throw new ArgumentException("Element must be of type XElement or XCData.", nameof(element));
        }
        
        Element = element;
    }
}