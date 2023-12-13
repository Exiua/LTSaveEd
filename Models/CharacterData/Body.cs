using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData;

namespace LTSaveEd.Models.CharacterData;

public class Body
{
    public BodyCore BodyCore { get; }
    public Head Head { get; }
    public Face Face { get; }
    public Breasts Breasts { get; }
    public Breasts BreastsCrotch { get; }


    public Body(XElement bodyNode)
    {
        BodyCore = new BodyCore(bodyNode.Element("bodyCore")!, this);
        Head = new Head(bodyNode, this);
        Face = new Face(bodyNode, this);
        Breasts = new Breasts(bodyNode.Element("breasts")!, bodyNode.Element("nipples")!, bodyNode.Element("milk")!, this, false);
        BreastsCrotch = new Breasts(bodyNode.Element("breastsCrotch")!, bodyNode.Element("nipplesCrotch")!, bodyNode.Element("milkCrotch")!, this, true);
    }
}