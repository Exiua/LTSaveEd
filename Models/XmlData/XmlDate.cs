using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models.XmlData;

public class XmlDate
{
    private XmlAttribute<int> Year { get; }
    private XmlAttribute<string> Month { get; }
    private XmlAttribute<int> Day { get; }

    public DateTime? Value
    {
        get
        {
            var month = Month.Value.ToUpper().ToMonthInt();
            return new DateTime(Year.Value, month, Day.Value);
        }
        set
        {
            if (value == null)
            {
                return;
            }
            
            var dateTime = value.Value;

            Year.Value = dateTime.Year;
            Month.Value = dateTime.Month.ToMonthString();
            Day.Value = dateTime.Day;
        }
    }
    
    public XmlDate(XElement coreNode)
    {
        Year = new XmlAttribute<int>(coreNode.GetChildsAttributeNode("yearOfBirth"));
        Month = new XmlAttribute<string>(coreNode.GetChildsAttributeNode("monthOfBirth"));
        Day = new XmlAttribute<int>(coreNode.GetChildsAttributeNode("dayOfBirth"));
    }

    public XmlDate(XAttribute yearNode, XAttribute monthNode, XAttribute dayNode)
    {
        Year = new XmlAttribute<int>(yearNode);
        Month = new XmlAttribute<string>(monthNode);
        Day = new XmlAttribute<int>(dayNode);
    }
}