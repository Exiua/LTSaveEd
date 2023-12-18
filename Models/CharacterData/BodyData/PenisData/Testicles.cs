using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

public class Testicles
{
    public XmlAttribute<int> CumExpulsion { get; }
    public XmlAttribute<int> CumRegeneration { get; }
    public XmlAttribute<int> CumStorage { get; }
    public XmlAttribute<int> NumberOfTesticles { get; }
    public XmlAttribute<float> StoredCum { get; }
    public XmlAttribute<int> TesticleSize { get; }
    public XmlAttribute<bool> Internal { get; }

    public Testicles(XElement testiclesNode)
    {
        CumExpulsion = new XmlAttribute<int>(testiclesNode.Attribute("cumExpulsion")!);
        CumRegeneration = new XmlAttribute<int>(testiclesNode.Attribute("cumRegeneration")!);
        CumStorage = new XmlAttribute<int>(testiclesNode.Attribute("cumStorage")!);
        NumberOfTesticles = new XmlAttribute<int>(testiclesNode.Attribute("numberOfTesticles")!);
        StoredCum = new XmlAttribute<float>(testiclesNode.Attribute("storedCum")!);
        TesticleSize = new XmlAttribute<int>(testiclesNode.Attribute("testicleSize")!);
        Internal = new XmlAttribute<bool>(testiclesNode.Attribute("internal")!);
    }
}