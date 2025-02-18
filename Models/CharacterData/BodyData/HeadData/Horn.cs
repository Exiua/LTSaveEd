using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

/// <summary>
///     Class models the horn node of the character's body data. Part of the <see cref="Head" /> model.
/// </summary>
/// <param name="hornNode">XElement of the horn node</param>
public class Horn(XElement hornNode)
{
    public ValueDisplayPair<string>[] HornTypes { get; } =
    [
        new("None", "NONE"), new("Antlers", "ANTLERS"),
        new("Dragon", "dsg_dragon_horn"),
        new("Dragon antler", "dsg_dragon_hornAntlers"),
        new("Dragon curled", "dsg_dragon_hornCurled"),
        new("Dragon curved", "dsg_dragon_hornCurved"),
        new("Unicorn", "HORSE_STRAIGHT"), new("Curled", "CURLED"),
        new("Curved", "CURVED"), new("Spiral", "SPIRAL"),
        new("Straight", "STRAIGHT"), new("Swept-back", "SWEPT_BACK"),
        new("Multi-branched", "REINDEER_RACK")
    ];
    
    public XmlAttribute<int> HornsPerRow { get; } = new(hornNode.Attribute("hornsPerRow")!);
    public LabeledXmlAttribute<int>Length { get; } = new(hornNode.Attribute("length")!, Collections.GetExtremityLabel);
    public XmlAttribute<int> Rows { get; } = new(hornNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(hornNode.Attribute("type")!);
}