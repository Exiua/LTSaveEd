using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Wing
{
    public ValueDisplayPair<string>[] WingTypes { get; } =
    [
        new("None", "NONE"), new("Angel", "ANGEL"),
        new("Demonic feathered", "DEMON_FEATHERED"), new("Demonic leathery", "DEMON_COMMON"),
        new("Dragon", "dsg_dragon_wing"), new("Dragon feathered", "dsg_dragon_wingFeathered"),
        new("Gryphon", "dsg_gryphon_wing"),
        new("Feathered", "FEATHERED"), new("Insect", "INSECT"),
        new("Leathery", "LEATHERY")
    ];
    
    public XmlAttribute<int> Size { get; }
    public XmlAttribute<string> Type { get; }

    public Wing(XElement wingNode)
    {
        Size = new XmlAttribute<int>(wingNode.Attribute("size")!);
        Type = new XmlAttribute<string>(wingNode.Attribute("type")!);
    }
}