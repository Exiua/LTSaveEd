using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class XmlText
{
    private readonly XElement _element;
    
    public string Value
    {
        get => _element.Value;
        set => _element.Value = value;
    }

    public XmlText(XElement element)
    {
        _element = element;
    }
}