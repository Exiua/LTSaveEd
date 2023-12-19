using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Spinneret
{
    public LabeledXmlAttribute<float> Capacity { get; }
    public LabeledXmlAttribute<int> Depth { get; }
    public LabeledXmlAttribute<int> Elasticity { get; }
    public LabeledXmlAttribute<int> Plasticity { get; }
    public LabeledXmlAttribute<float> StretchedCapacity { get; }
    public LabeledXmlAttribute<int> Wetness { get; }
    public XmlAttribute<bool> Virgin { get; }

    public Spinneret(XElement spinneretNode)
    {
        Capacity = new LabeledXmlAttribute<float>(spinneretNode.Attribute("capacity")!, Collections.GetCapacityLabel);
        Depth = new LabeledXmlAttribute<int>(spinneretNode.Attribute("depth")!, Collections.GetDepthLabel);
        Elasticity = new LabeledXmlAttribute<int>(spinneretNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
        Plasticity = new LabeledXmlAttribute<int>(spinneretNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
        StretchedCapacity = new LabeledXmlAttribute<float>(spinneretNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
        Wetness = new LabeledXmlAttribute<int>(spinneretNode.Attribute("wetness")!, Collections.GetWetnessLabel);
        Virgin = new XmlAttribute<bool>(spinneretNode.Attribute("virgin")!);
    }
}