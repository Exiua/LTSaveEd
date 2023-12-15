using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models;

public class World
{
    private DateTime? _currentDate;
    private TimeSpan? _currentTime;
    private DateTime StartDate { get; }
    private XmlAttribute<int> SecondsPassed { get; }

    public DateTime? CurrentDate
    {
        get => _currentDate;
        set
        {
            _currentDate = value;
            var currentDateTime = GetDateTime();
            var timePassed = (currentDateTime - StartDate)!;
            var secondsPassed = (int)timePassed.TotalSeconds;
            if (secondsPassed < 0)
            {
                _currentDate = StartDate.Add(TimeSpan.FromSeconds(SecondsPassed.Value));
            }
            else
            {
                SecondsPassed.Value = secondsPassed;
            }
        }
    }

    public TimeSpan? CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
            var currentDateTime = GetDateTime();
            var timePassed = (currentDateTime - StartDate)!;
            var secondsPassed = (int)timePassed.TotalSeconds;
            if (secondsPassed < 0)
            {
                var originalDateTime = StartDate.Add(TimeSpan.FromSeconds(SecondsPassed.Value));
                _currentTime = new TimeSpan(originalDateTime.Hour, originalDateTime.Minute, 0);
            }
            else
            {
                SecondsPassed.Value = secondsPassed;
            }
        }
    }

    public XmlAttribute<int> RalphDiscount { get;}
    public XmlAttribute<int> ScarlettPrice { get;}
    public XmlAttribute<int> EponaStamps { get;}
    public XmlAttribute<int> HelenaSlaveOrderDay { get;}
    public XmlAttribute<int> NatalyaPoints { get;}
    
    public World(XElement coreInfoNode, XElement dialogueFlagsNode)
    {
        var startDateNode = coreInfoNode.Element("date")!;
        var dayOfMonth = startDateNode.GetAttributeValue<int>("dayOfMonth");
        var hour = startDateNode.GetAttributeValue<int>("hour");
        var minute = startDateNode.GetAttributeValue<int>("minute");
        var month = startDateNode.GetAttributeValue<int>("month");
        var year = startDateNode.GetAttributeValue<int>("year");
        SecondsPassed = new XmlAttribute<int>(coreInfoNode.Attribute("secondsPassed")!);
        StartDate = new DateTime(year, month, dayOfMonth, hour, minute, 0);
        _currentDate = StartDate.Add(TimeSpan.FromSeconds(SecondsPassed.Value));
        _currentTime = new TimeSpan(_currentDate.Value.Hour, _currentDate.Value.Minute, 0);
        RalphDiscount = new XmlAttribute<int>(dialogueFlagsNode.GetChildsAttributeNode("ralphDiscount"));
        ScarlettPrice = new XmlAttribute<int>(dialogueFlagsNode.GetChildsAttributeNode("scarlettPrice"));
        EponaStamps = new XmlAttribute<int>(dialogueFlagsNode.GetChildsAttributeNode("eponaStamps"));
        HelenaSlaveOrderDay = new XmlAttribute<int>(dialogueFlagsNode.GetChildsAttributeNode("helenaSlaveOrderDay"));
        NatalyaPoints = new XmlAttribute<int>(dialogueFlagsNode.GetChildsAttributeNode("natalyaPoints"));
    }

    private DateTime GetDateTime()
    {
        var currentDate = _currentDate!.Value;
        var currentTime = _currentTime!.Value;
        return currentDate.Add(currentTime);
    }
}