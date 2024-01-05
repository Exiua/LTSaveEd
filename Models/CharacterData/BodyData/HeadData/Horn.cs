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
        new ValueDisplayPair<string>("None", "NONE"), new ValueDisplayPair<string>("Antlers", "ANTLERS"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_horn"),
        new ValueDisplayPair<string>("Dragon antler", "dsg_dragon_hornAntlers"),
        new ValueDisplayPair<string>("Dragon curled", "dsg_dragon_hornCurled"),
        new ValueDisplayPair<string>("Dragon curved", "dsg_dragon_hornCurved"),
        new ValueDisplayPair<string>("Unicorn", "HORSE_STRAIGHT"), new ValueDisplayPair<string>("Curled", "CURLED"),
        new ValueDisplayPair<string>("Curved", "CURVED"), new ValueDisplayPair<string>("Spiral", "SPIRAL"),
        new ValueDisplayPair<string>("Straight", "STRAIGHT"), new ValueDisplayPair<string>("Swept-back", "SWEPT_BACK"),
        new ValueDisplayPair<string>("Multi-branched", "REINDEER_RACK")
    ];
    
    public XmlAttribute<int> HornsPerRow { get; } = new(hornNode.Attribute("hornsPerRow")!);
    public LabeledXmlAttribute<int>Length { get; } = new(hornNode.Attribute("length")!, Collections.GetExtremityLabel);
    public XmlAttribute<int> Rows { get; } = new(hornNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(hornNode.Attribute("type")!);
}