using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.VaginaData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Vagina : BodyComponent
{
    public VaginaComponent VaginaComponent { get; }
    public GirlCum GirlCum { get; }
    
    public Vagina(XElement bodyNode, Body body) : base(body)
    {
        VaginaComponent = new VaginaComponent(bodyNode.Element("vagina")!);
        GirlCum = new GirlCum(bodyNode.Element("girlcum")!);
    }
}