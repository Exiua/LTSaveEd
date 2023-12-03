using System.Xml.Linq;

namespace LTSaveEd.Models;

public class Fetish
{
    public XmlAttribute<int> Desire { get; }
    public XmlAttribute<int> Xp { get; }
    public XmlAttribute<bool> Owned { get; }

    public string DesireValue
    {
        get
        {
            return Desire.Value switch
            {
                0 => "Hate",
                1 => "Dislike",
                2 => "Indifferent",
                3 => "Like",
                4 => "Love",
                _ => throw new Exception($"Invalid Desire Value: {Desire.Value}")
            };
        }
        set
        {
            Desire.Value = value switch
            {
                "Hate"          => 0,
                "Dislike"       => 1,
                "Indifferent"   => 2,
                "Like"          => 3,
                "Love"          => 4,
                _ => throw new Exception($"Invalid Desire Type: {value}")
            };
        }
    }

    public Fetish(XElement fetishNode)
    {
        var desireNode = fetishNode.Attribute("desire");
        if (desireNode == null)
        {
            desireNode = new XAttribute("desire", 2);
            fetishNode.Add(desireNode);
        }
        Desire = new XmlAttribute<int>(desireNode);
        
        var xpNode = fetishNode.Attribute("xp");
        if (xpNode == null)
        {
            xpNode = new XAttribute("xp", 0);
            fetishNode.Add(xpNode);
        }
        Xp = new XmlAttribute<int>(xpNode);
        
        var ownedNode = fetishNode.Attribute("o");
        if (ownedNode == null)
        {
            ownedNode = new XAttribute("o", false);
            fetishNode.Add(ownedNode);
        }
        Owned = new XmlAttribute<bool>(ownedNode);
    }
}