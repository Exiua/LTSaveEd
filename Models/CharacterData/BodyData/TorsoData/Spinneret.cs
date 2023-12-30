using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Spinneret(XElement spinneretNode)
{
    public LabeledXmlAttribute<float> Capacity { get; } = new(spinneretNode.Attribute("capacity")!, Collections.GetCapacityLabel);
    public LabeledXmlAttribute<int> Depth { get; } = new(spinneretNode.Attribute("depth")!, Collections.GetDepthLabel);
    public LabeledXmlAttribute<int> Elasticity { get; } = new(spinneretNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
    public LabeledXmlAttribute<int> Plasticity { get; } = new(spinneretNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
    public LabeledXmlAttribute<float> StretchedCapacity { get; } = new(spinneretNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
    public LabeledXmlAttribute<int> Wetness { get; } = new(spinneretNode.Attribute("wetness")!, Collections.GetWetnessLabel);
    public XmlAttribute<bool> Virgin { get; } = new(spinneretNode.Attribute("virgin")!);
}