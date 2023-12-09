using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.CharacterData;

namespace LTSaveEd.Models;

public class SaveData
{
    public bool Initialized { get; private set; }
    public Character CurrentCharacter { get; private set; }= null!;

    internal XDocument SaveDataXml { get; private set; } = null!;

    private List<ValueDisplayPair> CharacterIds { get; } = new(){ new ValueDisplayPair("Player", "PlayerCharacter") };
    private Dictionary<string, Character> CharacterCache { get; } = new();
    
    
    public async Task Initialize(Stream data)
    {
        var cancellationToken = new CancellationToken();
        SaveDataXml = await XDocument.LoadAsync(data, LoadOptions.None, cancellationToken);
        PopulateCharacterIds();
        Initialized = true;
    }

    private void PopulateCharacterIds()
    {
        var characterIdNodes = SaveDataXml.Descendants("NPC").Select(npc => npc.Descendants("id").First());
        foreach (var idNode in characterIdNodes)
        {
            var id = idNode.Attribute("value")!;
            var character = idNode.Parent!.Parent!; // id > core > character
            var nameElement = character.Descendants("name").First();
            var femininityString = character.GetAttributeByChildSequence("body", "bodyCore", "femininity").Value;
            var femininity = int.Parse(femininityString);
            var name = femininity switch
            {
                < 40 => nameElement.Attribute("nameMasculine")!.Value,
                >= 40 and <= 60 => nameElement.Attribute("nameAndrogynous")!.Value,
                > 60 => nameElement.Attribute("nameFeminine")!.Value
            };
            CharacterIds.Add(new ValueDisplayPair(name, id.Value));
        }
        Console.WriteLine(CharacterIds.Select(id => id.Value).ToFormattedString());
        LoadCharacter(CharacterIds[0]);
    }

    private void LoadCharacter(ValueDisplayPair characterIdPair)
    {
        var characterId = characterIdPair.Value;
        if (CharacterCache.TryGetValue(characterId, out var character))
        {
            CurrentCharacter = character;
            return;
        }
        
        var characterNode = SaveDataXml.FindCharacterById(characterId);
        CurrentCharacter = new Character(characterNode);
        CharacterCache.Add(characterId, CurrentCharacter);
    }
}