using System.Xml.Linq;
using LTSaveEd.Models.CharacterData.BodyData.HeadData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public class Head(XElement bodyNode, Body body) : BodyComponent(body)
{
    public Antennae Antennae { get; } = new(bodyNode.Element("antennae")!);
    public Ear Ear { get; } = new(bodyNode.Element("ear")!);
    public Hair Hair { get; } = new(bodyNode.Element("hair")!);
    public Horn Horn { get; } = new(bodyNode.Element("horn")!);
}