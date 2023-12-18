using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models;

public class CharacterShort
{
    public XmlAttribute<string> Id { get; set; }
    public XmlAttribute<string> Name { get; set; }
    public XmlAttribute<string> Femininity { get; set; }
    public XmlAttribute<string> Subspecies { get; set; }

    public CharacterShort(XElement familyNode, bool mother)
    {
        string id;
        string name;
        string femininity;
        string subspecies;
        if (mother)
        {
            id = "motherId";
            name = "motherName";
            femininity = "motherFemininity";
            subspecies = "motherSubspecies";
        }
        else
        {
            id = "fatherId";
            name = "fatherName";
            femininity = "fatherFemininity";
            subspecies = "fatherSubspecies";
        }
        Id = new XmlAttribute<string>(familyNode.GetChildsAttributeNode(id));
        Name = new XmlAttribute<string>(familyNode.GetChildsAttributeNode(name));
        Femininity = new XmlAttribute<string>(familyNode.GetChildsAttributeNode(femininity));
        Subspecies = new XmlAttribute<string>(familyNode.GetChildsAttributeNode(subspecies));
    }
}