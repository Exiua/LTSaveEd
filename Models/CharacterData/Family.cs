using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Family
{
    public CharacterShort Mother { get; set; }
    public CharacterShort Father { get; set; }
    public XmlDate DateOfConception { get; }
    
    public Family(XElement familyNode)
    {
        Mother = new CharacterShort(familyNode, true);
        Father = new CharacterShort(familyNode, false);
        var yearNode = familyNode.GetChildsAttributeNode("yearOfConception");
        var monthNode = familyNode.GetChildsAttributeNode("monthOfConception");
        var dayNode = familyNode.GetChildsAttributeNode("dayOfConception");
        DateOfConception = new XmlDate(yearNode, monthNode, dayNode);
    }
}