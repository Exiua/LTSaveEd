using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

/// <summary>
///     Class models the antennae node of the character's body data. Part of the <see cref="Head" /> model.
/// </summary>
/// <param name="antennaeNode">XElement of the antennae node</param>
public class Antennae(XElement antennaeNode)
{
    public ValueDisplayPair[] AntennaeTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE")
    ]; // TODO: Find antennae types
    
    public XmlAttribute<int> AntennaePerRow { get; } = new(antennaeNode.Attribute("antennaePerRow")!);
    public LabeledXmlAttribute<int> Length { get; } = new(antennaeNode.Attribute("length")!, Collections.GetExtremityLabel);
    public XmlAttribute<int> Rows { get; } = new(antennaeNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(antennaeNode.Attribute("type")!);
}