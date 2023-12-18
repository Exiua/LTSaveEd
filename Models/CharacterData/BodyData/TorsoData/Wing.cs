using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Wing
{
    public ValueDisplayPair[] WingTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Demonic feathered", "DEMON_FEATHERED"), new ValueDisplayPair("Demonic leathery", "DEMON_COMMON"),
        new ValueDisplayPair("Dragon", "dsg_dragon_wing"), new ValueDisplayPair("Dragon feathered", "dsg_dragon_wingFeathered"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_wing"),
        new ValueDisplayPair("Feathered", "FEATHERED"), new ValueDisplayPair("Insect", "INSECT"),
        new ValueDisplayPair("Leathery", "LEATHERY")
    ];
    
    public XmlAttribute<int> Size { get; }
    public XmlAttribute<string> Type { get; }

    public Wing(XElement wingNode)
    {
        Size = new XmlAttribute<int>(wingNode.Attribute("size")!);
        Type = new XmlAttribute<string>(wingNode.Attribute("type")!);
    }
}