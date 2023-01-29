using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Models.CharacterModel;
using LTSaveEd.Utility;

namespace LTSaveEd.Models;

public class SaveFile
{
    public static readonly SaveFile savefile;

    public XElement currentCharacterElement { get; private set; }

    public Character currentCharacter { get; set; }
    
    private XDocument root = null!;
    private Dictionary<XElement, Character> _loadedCharacters = new();

    private SaveFile() { }

    static SaveFile()
    {
        savefile = new SaveFile();
    }

    public void LoadData(string filepath)
    {
        root = XDocument.Load(filepath);
        currentCharacterElement = GetTagByName("playerCharacter").GetChildByName("character");
        if (_loadedCharacters.ContainsKey(currentCharacterElement))
        {
            currentCharacter = _loadedCharacters[currentCharacterElement];
        }
        else
        {
            currentCharacter = new Character(currentCharacterElement);
            _loadedCharacters[currentCharacterElement] = currentCharacter;
        }
    }

    public XElement GetTagByName(string tagName)
    {
        var tag = (from el in root.Descendants(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFoundException(tagName);
        }
        return tag;
    }

    public XElement GetDescendantByName(XElement parent, string tagName)
    {
        var tag = (from el in parent.Descendants(tagName) select el).First();
        if (tag is null)
        {
            throw new TagNotFoundException(tagName);
        }
        return tag;
    }

    public XElement[] GetNpcList()
    {
        var tag = (from el in root.Descendants("NPC") select el).ToArray();
        if (tag is null)
        {
            throw new TagNotFoundException("NPC");
        }

        return tag;
    }
}