using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Fetish
{
    private XmlAttribute<int> Desire { get; }
    public XmlAttribute<int> Xp { get; }
    public FetishOwnedAttribute Owned { get; }

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

    public Fetish(XElement fetishNode, bool suppressDesire = false)
    {
        var desireNode = fetishNode.Attribute("desire");
        if (desireNode is null)
        {
            desireNode = new XAttribute("desire", 2);
            if(!suppressDesire)
            {
                fetishNode.Add(desireNode);
            }
        }
        Desire = new XmlAttribute<int>(desireNode);
        
        var xpNode = fetishNode.Attribute("xp");
        if (xpNode is null)
        {
            xpNode = new XAttribute("xp", 0);
            fetishNode.Add(xpNode);
        }
        Xp = new XmlAttribute<int>(xpNode);

        Owned = new FetishOwnedAttribute(fetishNode);
        var ownedNode = fetishNode.Attribute("o");
        if (ownedNode is not null)
        {
            Owned.Initialize(ownedNode);
        }
    }
}