using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Models.CharacterModel.CharacterCoreModel;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel;

public class Character
{
    public CharacterCore core { get; }
    public CharacterBody body  { get; set; }
    public bool player { get; set; }

    public Character(XElement characterElement)
    {
        if (characterElement.Name != "character")
        {
            throw new IncorrectElementException(characterElement);
        }

        player = characterElement.Parent?.Name == "playerCharacter";
        core = new CharacterCore(characterElement.GetChildByName("core"));
    }
}