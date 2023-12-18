using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

public class Antennae(XElement antennaeNode)
{
    public ValueDisplayPair[] AntennaeTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE")
    ]; // TODO: Find antennae types
    
    public XmlAttribute<int> AntennaePerRow { get; } = new(antennaeNode.Attribute("antennaePerRow")!);
    public XmlAttribute<int> Length { get; } = new(antennaeNode.Attribute("length")!);
    public XmlAttribute<int> Rows { get; } = new(antennaeNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(antennaeNode.Attribute("type")!);

}