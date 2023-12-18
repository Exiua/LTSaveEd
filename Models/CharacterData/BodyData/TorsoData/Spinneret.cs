using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Spinneret
{
    public XmlAttribute<float> Capacity { get; }
    public XmlAttribute<int> Depth { get; }
    public XmlAttribute<int> Elasticity { get; }
    public XmlAttribute<int> Plasticity { get; }
    public XmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<int> Wetness { get; }
    public XmlAttribute<bool> Virgin { get; }

    public Spinneret(XElement spinneretNode)
    {
        Capacity = new XmlAttribute<float>(spinneretNode.Attribute("capacity")!);
        Depth = new XmlAttribute<int>(spinneretNode.Attribute("depth")!);
        Elasticity = new XmlAttribute<int>(spinneretNode.Attribute("elasticity")!);
        Plasticity = new XmlAttribute<int>(spinneretNode.Attribute("plasticity")!);
        StretchedCapacity = new XmlAttribute<float>(spinneretNode.Attribute("stretchedCapacity")!);
        Wetness = new XmlAttribute<int>(spinneretNode.Attribute("wetness")!);
        Virgin = new XmlAttribute<bool>(spinneretNode.Attribute("virgin")!);
    }
}