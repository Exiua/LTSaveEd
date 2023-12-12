using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData;

namespace LTSaveEd.Models.CharacterData;

public class Body
{
    public BodyCore BodyCore { get; }


    public Body(XElement bodyNode)
    {
        BodyCore = new BodyCore(bodyNode.Element("bodyCore")!, this);
    }
}