using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

public class Horn(XElement hornNode)
{
    public ValueDisplayPair[] HornTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Antlers", "ANTLERS"),
        new ValueDisplayPair("Dragon", "dsg_dragon_horn"),
        new ValueDisplayPair("Dragon antler", "dsg_dragon_hornAntlers"),
        new ValueDisplayPair("Dragon curled", "dsg_dragon_hornCurled"),
        new ValueDisplayPair("Dragon curved", "dsg_dragon_hornCurved"),
        new ValueDisplayPair("Unicorn", "HORSE_STRAIGHT"), new ValueDisplayPair("Curled", "CURLED"),
        new ValueDisplayPair("Curved", "CURVED"), new ValueDisplayPair("Spiral", "SPIRAL"),
        new ValueDisplayPair("Straight", "STRAIGHT"), new ValueDisplayPair("Swept-back", "SWEPT_BACK"),
        new ValueDisplayPair("Multi-branched", "REINDEER_RACK")
    ];
    
    public XmlAttribute<int> HornsPerRow { get; } = new(hornNode.Attribute("hornsPerRow")!);
    public XmlAttribute<int> Length { get; } = new(hornNode.Attribute("length")!);
    public XmlAttribute<int> Rows { get; } = new(hornNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(hornNode.Attribute("type")!);

}