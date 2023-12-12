using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

public class Horn(XElement hornNode)
{
    public XmlAttribute<int> HornsPerRow { get; } = new(hornNode.Attribute("hornsPerRow")!);
    public XmlAttribute<int> Length { get; } = new(hornNode.Attribute("length")!);
    public XmlAttribute<int> Rows { get; } = new(hornNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(hornNode.Attribute("type")!);

}