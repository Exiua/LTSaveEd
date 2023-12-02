using System.Xml;
using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class DateOfBirth(XElement coreNode)
{
    private XmlAttribute<int> Year { get; } = new(coreNode.GetChildsAttributeNode("yearOfBirth"));
    private XmlAttribute<string> Month { get; } = new(coreNode.GetChildsAttributeNode("monthOfBirth"));
    private XmlAttribute<int> Day { get; } = new(coreNode.GetChildsAttributeNode("dayOfBirth"));

    public DateTime? Value
    {
        get
        {
            var month = Month.Value.ToUpper() switch
            {
                "JANUARY" => 1,
                "FEBRUARY" => 2,
                "MARCH" => 3,
                "APRIL" => 4,
                "MAY" => 5,
                "JUNE" => 6,
                "JULY" => 7,
                "AUGUST" => 8,
                "SEPTEMBER" => 9,
                "OCTOBER" => 10,
                "NOVEMBER" => 11,
                "DECEMBER" => 12,
                _ => throw new Exception($"Invalid month: {Month.Value}")
            };
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
            Month.Value = dateTime.Month switch
            {
                1 => "JANUARY",
                2 => "FEBRUARY",
                3 => "MARCH",
                4 => "APRIL",
                5 => "MAY",
                6 => "JUNE",
                7 => "JULY",
                8 => "AUGUST",
                9 => "SEPTEMBER",
                10 => "OCTOBER",
                11 => "NOVEMBER",
                12 => "DECEMBER",
                _ => throw new Exception($"Invalid month number: {dateTime.Month}")
            };
            Day.Value = dateTime.Day;
        }
    }

}