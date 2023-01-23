using System.Linq;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Models;

public class SaveFile
{
    public static readonly SaveFile savefile;

    public XElement currentCharacter = null!;
    
    private XDocument root = null!;
    
    private SaveFile() { }

    static SaveFile()
    {
        savefile = new SaveFile();
    }

    public void LoadData(string filepath)
    {
        root = XDocument.Load(filepath);
        currentCharacter = GetTagByName("playerCharacter");
    }

    public XElement GetTagByName(string tagName)
    {
        var tag = (from el in root.Descendants(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFound(tagName);
        }
        return tag;
    }

    public XElement GetDescendantByName(XElement parent, string tagName)
    {
        var tag = (from el in parent.Descendants(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFound(tagName);
        }
        return tag;
    }

    public XElement[] GetNpcList()
    {
        var tag = (from el in root.Descendants("NPC") select el).ToArray();
        if (tag is null)
        {
            throw new TagNotFound("NPC");
        }

        return tag;
    }
}