using System.Xml.Linq;

namespace LTSaveEd.Models.XmlData;

public class NullableXmlCData(XElement parent, string elementTagName) : NullableXmlObject(parent)
{
    private XCData? CData => Node as XCData;
    
    public string? Value
    {
        get => CData is null ? "" : CData.Value;
        set
        {
            if (value is null)
            {
                Exists = false;
                return;
            }
            
            Exists = true; // Guarantees that the node exists
            CData!.Value = value;
        }
    }
    
    protected override XObject CreateNode()
    {
        var element = new XElement(elementTagName, new XCData("placeholder"));
        Parent.Add(element);
        return element;
    }
}