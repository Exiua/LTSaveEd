using System.Xml.Linq;

namespace LTSaveEd.Models;

public class Name(XElement nameNode, XElement surnameNode)
{
    public XmlAttribute<string> Androgynous { get; } = new(nameNode.Attribute("nameAndrogynous")!);
    public XmlAttribute<string> Feminine { get; } = new(nameNode.Attribute("nameFeminine")!);
    public XmlAttribute<string> Masculine { get; } = new(nameNode.Attribute("nameMasculine")!);
    public XmlAttribute<string> Surname { get; } = new(surnameNode.Attribute("value")!);
}