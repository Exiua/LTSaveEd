using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Wing
{
    public ValueDisplayPair<string>[] WingTypes { get; } =
    [
        new ValueDisplayPair<string>("None", "NONE"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Demonic feathered", "DEMON_FEATHERED"), new ValueDisplayPair<string>("Demonic leathery", "DEMON_COMMON"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_wing"), new ValueDisplayPair<string>("Dragon feathered", "dsg_dragon_wingFeathered"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_wing"),
        new ValueDisplayPair<string>("Feathered", "FEATHERED"), new ValueDisplayPair<string>("Insect", "INSECT"),
        new ValueDisplayPair<string>("Leathery", "LEATHERY")
    ];
    
    public XmlAttribute<int> Size { get; }
    public XmlAttribute<string> Type { get; }

    public Wing(XElement wingNode)
    {
        Size = new XmlAttribute<int>(wingNode.Attribute("size")!);
        Type = new XmlAttribute<string>(wingNode.Attribute("type")!);
    }
}