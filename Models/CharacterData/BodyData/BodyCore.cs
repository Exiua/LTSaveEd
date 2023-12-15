using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class BodyCore : BodyComponent
{
    public ValueDisplayPair[] BodyMaterials { get; } =
    [
        new ValueDisplayPair("Flesh", "FLESH"), new ValueDisplayPair("Slime", "SLIME"),
        new ValueDisplayPair("Fire", "FIRE"), new ValueDisplayPair("Water", "WATER"),
        new ValueDisplayPair("Ice", "ICE"), new ValueDisplayPair("Storm-clouds", "AIR"),
        new ValueDisplayPair("Stone", "STONE"), new ValueDisplayPair("Rubber", "RUBBER"),
        new ValueDisplayPair("Energy", "ENERGY")
    ];

    public static ValueDisplayPair[] PubicHairTypes => Collections.HairTypes;

    public static ValueDisplayPair[] SubspeciesOverrides => Collections.SubspeciesOverrides;

    public XmlAttribute<string> BodyMaterial { get; }
    public XmlAttribute<int> BodySize { get; }
    public XmlAttribute<int> Femininity { get; }
    public XmlAttribute<bool> Feral { get; }
    public XmlAttribute<string> GenitalArrangement { get; }
    public XmlAttribute<int> Height { get; }
    public XmlAttribute<int> Muscle { get; }
    public XmlAttribute<bool> PiercedStomach { get; }
    public XmlAttribute<string> PubicHair { get; }
    public XmlAttribute<string> SubspeciesOverride { get; }
    public XmlAttribute<bool> TakesAfterMother { get; }
    

    public BodyCore(XElement bodyCoreNode, Body body) : base(body)
    {
        BodyMaterial = new XmlAttribute<string>(bodyCoreNode.Attribute("bodyMaterial")!);
        BodySize = new XmlAttribute<int>(bodyCoreNode.Attribute("bodySize")!);
        Femininity = new XmlAttribute<int>(bodyCoreNode.Attribute("femininity")!);
        Feral = new XmlAttribute<bool>(bodyCoreNode.Attribute("feral")!);
        GenitalArrangement = new XmlAttribute<string>(bodyCoreNode.Attribute("genitalArrangement")!);
        Height = new XmlAttribute<int>(bodyCoreNode.Attribute("height")!);
        Muscle = new XmlAttribute<int>(bodyCoreNode.Attribute("muscle")!);
        PiercedStomach = new XmlAttribute<bool>(bodyCoreNode.Attribute("piercedStomach")!);
        PubicHair = new XmlAttribute<string>(bodyCoreNode.Attribute("pubicHair")!);
        SubspeciesOverride = new XmlAttribute<string>(bodyCoreNode.Attribute("subspecies")!);
        TakesAfterMother = new XmlAttribute<bool>(bodyCoreNode.Attribute("takesAfterMother")!);
    }
}