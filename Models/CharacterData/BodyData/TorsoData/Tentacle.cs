using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Tentacle
{
    public ValueDisplayPair[] TentacleTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE")
    ]; // TODO: Find tentacle types

    public XmlAttribute<int> Count { get; }
    public XmlAttribute<int> Girth { get; }
    public XmlAttribute<float> Length { get; }
    public XmlAttribute<string> Type { get; }

    public Tentacle(XElement tentacleNode)
    {
        Count = new XmlAttribute<int>(tentacleNode.Attribute("count")!);
        Girth = new XmlAttribute<int>(tentacleNode.Attribute("girth")!);
        Length = new XmlAttribute<float>(tentacleNode.Attribute("length")!);
        Type = new XmlAttribute<string>(tentacleNode.Attribute("type")!);
    }
}