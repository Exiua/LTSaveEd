using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class CharacterShort
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Femininity { get; set; }
    public string Subspecies { get; set; }

    public CharacterShort(string id, string name, string femininity, string subspecies)
    {
        Id = id;
        Name = name;
        Femininity = femininity;
        Subspecies = subspecies;
    }

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
        Id = familyNode.GetChildsAttribute<string>(id);
        Name = familyNode.GetChildsAttribute<string>(name);
        Femininity = familyNode.GetChildsAttribute<string>(femininity);
        Subspecies = familyNode.GetChildsAttribute<string>(subspecies);
    }
}