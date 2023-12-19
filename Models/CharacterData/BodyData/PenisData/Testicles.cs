using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

public class Testicles
{
    public XmlAttribute<int> CumExpulsion { get; }
    public LabeledXmlAttribute<int> CumRegeneration { get; }
    public LabeledXmlAttribute<int> CumStorage { get; }
    public XmlAttribute<int> NumberOfTesticles { get; }
    public XmlAttribute<float> StoredCum { get; }
    public LabeledXmlAttribute<int> TesticleSize { get; }
    public XmlAttribute<bool> Internal { get; }

    public Testicles(XElement testiclesNode)
    {
        CumExpulsion = new XmlAttribute<int>(testiclesNode.Attribute("cumExpulsion")!);
        CumRegeneration = new LabeledXmlAttribute<int>(testiclesNode.Attribute("cumRegeneration")!, Collections.GetFluidRegenerationLabel);
        CumStorage = new LabeledXmlAttribute<int>(testiclesNode.Attribute("cumStorage")!, GetCumStorageLabel);
        NumberOfTesticles = new XmlAttribute<int>(testiclesNode.Attribute("numberOfTesticles")!);
        StoredCum = new XmlAttribute<float>(testiclesNode.Attribute("storedCum")!);
        TesticleSize = new LabeledXmlAttribute<int>(testiclesNode.Attribute("testicleSize")!, GetTesticleSizeLabel);
        Internal = new XmlAttribute<bool>(testiclesNode.Attribute("internal")!);
    }

    private static string GetCumStorageLabel(int value)
    {
        return value switch
        {
            <= 0 => "None",
            > 0 and < 10 => "Trickle",
            >= 10 and < 20 => "Average",
            >= 20 and < 30 => "Large",
            >= 30 and < 100 => "Huge",
            >= 100 and < 1000 => "Extreme",
            >= 1000 => "Monstrous"
        };
    }

    private static string GetTesticleSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Vestigial",
            1 => "Tiny",
            2 => "Average-sized",
            3 => "Large",
            4 => "Huge",
            5 => "Massive",
            6 => "Gigantic",
            >= 7 => "Absurdly Enormous"
        };
    }
}