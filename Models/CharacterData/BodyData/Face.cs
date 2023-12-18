using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.FaceData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Face : BodyComponent
{
    public FaceComponent FaceComponent { get; }
    public Mouth Mouth { get; }
    public Tongue Tongue { get; }
    public Eye Eye { get; }

    public Face(XElement bodyNode, Body body) : base(body)
    {
        FaceComponent = new FaceComponent(bodyNode.Element("face")!);
        Mouth = new Mouth(bodyNode.Element("mouth")!);
        Tongue = new Tongue(bodyNode.Element("tongue")!);
        Eye = new Eye(bodyNode.Element("eye")!);
    }
}