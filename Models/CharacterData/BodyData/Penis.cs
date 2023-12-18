using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.PenisData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Penis : BodyComponent
{
    public PenisComponent PenisComponent { get; }
    public Testicles Testicles { get; }
    public Cum Cum { get; }
    
    public Penis(XElement bodyNode, Body body) : base(body)
    {
        PenisComponent = new PenisComponent(bodyNode.Element("penis")!);
        Testicles = new Testicles(bodyNode.Element("testicles")!);
        Cum = new Cum(bodyNode.Element("cum")!);
    }
}