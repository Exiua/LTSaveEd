using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.BreastsData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Breasts : BodyComponent
{
    public BreastsComponent BreastsComponent { get; }
    public Nipples Nipples { get; }
    public Milk Milk { get; }
    public bool BreastsCrotch { get; }
    
    public Breasts(XElement breastsNode, XElement nipplesNode, XElement milkNode, Body body, bool breastsCrotch) : base(body)
    {
        BreastsCrotch = breastsCrotch;
        BreastsComponent = new BreastsComponent(breastsNode, breastsCrotch);
        Nipples = new Nipples(nipplesNode);
        Milk = new Milk(milkNode);
    }
}