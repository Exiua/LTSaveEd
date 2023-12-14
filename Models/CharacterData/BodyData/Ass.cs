using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.AssData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Ass : BodyComponent
{
    public Leg Leg { get; }
    public AssComponent AssComponent { get; }
    public Anus Anus { get; }
    
    public Ass(XElement bodyNode, Body body) : base(body)
    {
        Leg = new Leg(bodyNode.Element("leg")!);
        AssComponent = new AssComponent(bodyNode.Element("ass")!);
        Anus = new Anus(bodyNode.Element("anus")!);
    }
}