using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class BodyCore : BodyComponent
{
    public ValueDisplayPair<string>[] BodyMaterials { get; } =
    [
        new ValueDisplayPair<string>("Flesh", "FLESH"), new ValueDisplayPair<string>("Slime", "SLIME"),
        new ValueDisplayPair<string>("Fire", "FIRE"), new ValueDisplayPair<string>("Water", "WATER"),
        new ValueDisplayPair<string>("Ice", "ICE"), new ValueDisplayPair<string>("Storm-clouds", "AIR"),
        new ValueDisplayPair<string>("Stone", "STONE"), new ValueDisplayPair<string>("Rubber", "RUBBER"),
        new ValueDisplayPair<string>("Energy", "ENERGY")
    ];

    public static ValueDisplayPair<string>[] PubicHairTypes => Collections.HairTypes;

    public static ValueDisplayPair<string>[] SubspeciesOverrides => Collections.SubspeciesOverrides;

    public XmlAttribute<string> BodyMaterial { get; }
    public LabeledXmlAttribute<int> BodySize { get; }
    public LabeledXmlAttribute<int> Femininity { get; }
    public XmlAttribute<bool> Feral { get; }
    public XmlAttribute<string> GenitalArrangement { get; }
    public XmlAttribute<int> Height { get; }
    public LabeledXmlAttribute<int> Muscle { get; }
    public XmlAttribute<bool> PiercedStomach { get; }
    public XmlAttribute<string> PubicHair { get; }
    public XmlAttribute<string> SubspeciesOverride { get; }
    public XmlAttribute<bool> TakesAfterMother { get; }
    

    public BodyCore(XElement bodyCoreNode, Body body) : base(body)
    {
        BodyMaterial = new XmlAttribute<string>(bodyCoreNode.Attribute("bodyMaterial")!);
        BodySize = new LabeledXmlAttribute<int>(bodyCoreNode.Attribute("bodySize")!, GetBodySizeLabel);
        Femininity = new LabeledXmlAttribute<int>(bodyCoreNode.Attribute("femininity")!, GetFemininityLabel);
        Feral = new XmlAttribute<bool>(bodyCoreNode.Attribute("feral")!);
        GenitalArrangement = new XmlAttribute<string>(bodyCoreNode.Attribute("genitalArrangement")!);
        Height = new XmlAttribute<int>(bodyCoreNode.Attribute("height")!);
        Muscle = new LabeledXmlAttribute<int>(bodyCoreNode.Attribute("muscle")!, GetMuscleLabel);
        PiercedStomach = new XmlAttribute<bool>(bodyCoreNode.Attribute("piercedStomach")!);
        PubicHair = new XmlAttribute<string>(bodyCoreNode.Attribute("pubicHair")!);
        SubspeciesOverride = new XmlAttribute<string>(bodyCoreNode.Attribute("subspecies")!);
        TakesAfterMother = new XmlAttribute<bool>(bodyCoreNode.Attribute("takesAfterMother")!);
    }

    private static string GetBodySizeLabel(int value)
    {
        return value switch
        {
            < 20 => "Skinny",
            >= 20 and < 40 => "Slender",
            >= 40 and < 60 => "Average",
            >= 60 and < 80 => "Large",
            >= 80 => "Huge"
        };
    }

    private static string GetFemininityLabel(int value)
    {
        return value switch
        {
            < 20 => "Very Masculine",
            >= 20 and < 40 => "Masculine",
            >= 40 and < 60 => "Androgynous",
            >= 60 and < 80 => "Feminine",
            >= 80 => "Very Feminine"
        };
    }

    private static string GetMuscleLabel(int value)
    {
        return value switch
        {
            < 20 => "Soft",
            >= 20 and < 40 => "Lightly Muscled",
            >= 40 and < 60 => "Toned",
            >= 60 and < 80 => "Muscular",
            >= 80 => "Ripped"
        };
    }
}