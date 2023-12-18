using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class CharacterShortData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Femininity { get; set; }
    public string Subspecies { get; set; }
    
    public CharacterShortData(string id, string name, string femininity, string subspecies)
    {
        Id = id;
        Name = name;
        Femininity = femininity;
        Subspecies = subspecies;
    }
    
    public CharacterShortData(XElement characterNode)
    {
        var coreNode = characterNode.Element("core")!;
        var nameNode = coreNode.Element("name")!;
        var bodyCoreNode = characterNode.Element("body")!.Element("bodyCore")!;
        var femininity = int.Parse(bodyCoreNode.Attribute("femininity")!.Value);
        Id = coreNode.Element("id")!.Attribute("value")!.Value;
        Femininity = femininity switch
        {
            < 20 => "VERY_MASCULINE",
            >= 20 and < 40 => "MASCULINE",
            >= 40 and < 60 => "ANDROGYNOUS",
            >= 60 and < 80 => "FEMININE",
            >= 80 => "VERY_FEMININE"
        };
        Subspecies = bodyCoreNode.Attribute("subspecies")!.Value;
        Name = femininity switch
        {
            < 40 => nameNode.Attribute("nameMasculine")!.Value,
            >= 40 and <= 60 => nameNode.Attribute("nameAndrogynous")!.Value,
            > 60 => nameNode.Attribute("nameFeminine")!.Value
        };
    }
}