using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.CharacterData;

public class NpcCharacter : AbstractCharacter
{
    public NpcCharacter(XElement npcElement)
    {
        if (npcElement.Name != "NPC")
        {
            throw new IncorrectElementException(npcElement);
        }
        
        XElement coreElement = npcElement.GetDescendantByName("core");
        id = coreElement.GetChildByName("id").GetAttributeValueByName();
        var nameElement = coreElement.GetChildByName("name");
        
    }
}