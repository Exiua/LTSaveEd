using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Tentacle
{
    public ValueDisplayPair<string>[] TentacleTypes { get; } =
    [
        new ValueDisplayPair<string>("None", "NONE")
    ]; // TODO: Find tentacle types

    public XmlAttribute<int> Count { get; }
    public LabeledXmlAttribute<int> Girth { get; }
    public XmlAttribute<float> Length { get; }
    public XmlAttribute<string> Type { get; }

    public Tentacle(XElement tentacleNode)
    {
        Count = new XmlAttribute<int>(tentacleNode.Attribute("count")!);
        Girth = new LabeledXmlAttribute<int>(tentacleNode.Attribute("girth")!, Collections.GetAppendageGirthLabel);
        Length = new XmlAttribute<float>(tentacleNode.Attribute("length")!);
        Type = new XmlAttribute<string>(tentacleNode.Attribute("type")!);
    }
}