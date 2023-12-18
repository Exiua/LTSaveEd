using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.TorsoData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Torso : BodyComponent
{
    public TorsoComponent TorsoComponent { get; }
    public Tail Tail { get; }
    public Tentacle Tentacle { get; }
    public Wing Wing { get; }
    public Spinneret Spinneret { get; }
    public Arm Arm { get; }

    public Torso(XElement bodyNode, Body body) : base(body)
    {
        TorsoComponent = new TorsoComponent(bodyNode.Element("torso")!);
        Tail = new Tail(bodyNode.Element("tail")!);
        Tentacle = new Tentacle(bodyNode.Element("tentacle")!);
        Wing = new Wing(bodyNode.Element("wing")!);
        Spinneret = new Spinneret(bodyNode.Element("spinneret")!);
        Arm = new Arm(bodyNode.Element("arm")!);
    }
}