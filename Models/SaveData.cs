using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.CharacterData;

namespace LTSaveEd.Models;

public class SaveData
{
    private bool _initialized;

    public bool Initialized
    {
        get => _initialized;
        private set
        {
            _initialized = value;
            if (!value)
            {
                CharacterIds.Clear();
                CharacterIds.Add(new ValueDisplayPair("Player", "PlayerCharacter"));
                CharacterCache.Clear();
                IdNameLookup.Clear();
            }
        }
    }

    public Character CurrentCharacter { get; private set; }= null!;
    public World WorldData { get; private set; } = null!;

    internal XDocument SaveDataXml { get; private set; } = null!;

    public List<ValueDisplayPair> CharacterIds { get; } = [new ValueDisplayPair("Player", "PlayerCharacter")];
    private Dictionary<string, Character> CharacterCache { get; } = new();
    private Dictionary<string, string> IdNameLookup { get; } = new();
    private Dictionary<string, XElement> IdCharacterLookup { get; } = new();
    
    
    public async Task<bool> Initialize(Stream data)
    {
        Initialized = false;
        var cancellationToken = new CancellationToken();
        SaveDataXml = await XDocument.LoadAsync(data, LoadOptions.None, cancellationToken);
        var coreInfoNode = SaveDataXml.Descendants("coreInfo").First();
        var dialogueFlagsNode = SaveDataXml.Descendants("dialogueFlags").First();
        WorldData = new World(coreInfoNode, dialogueFlagsNode);
        PopulateCharacterIds();
        Initialized = LoadCharacter(CharacterIds[0]);
        return Initialized;
    }

    private void PopulateCharacterIds()
    {
        var playerNode = SaveDataXml.Descendants("playerCharacter").First().Element("character")!;
        IdNameLookup.Add("PlayerCharacter", "Player");
        IdCharacterLookup.Add("PlayerCharacter", playerNode);
        
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
            var idValue = id.Value;
            CharacterIds.Add(new ValueDisplayPair(name, idValue));
            IdNameLookup.Add(idValue, name);
            IdCharacterLookup.Add(idValue, character);
        }
        //Console.WriteLine(CharacterIds.Select(id => id.Value).ToFormattedString());
    }

    private XElement GetCharacterNode(string characterId)
    {
        return IdCharacterLookup[characterId];
    }

    public CharacterShortData GetCharacterShortData(string characterId)
    {
        if (CharacterCache.TryGetValue(characterId, out var character))
        {
            return character.Shorten();
        }
        var characterNode = GetCharacterNode(characterId);
        return new CharacterShortData(characterNode);
    }
    
    private bool LoadCharacter(ValueDisplayPair characterIdPair)
    {
        var characterId = characterIdPair.Value;
        if (CharacterCache.TryGetValue(characterId, out var character))
        {
            CurrentCharacter = character;
            return true;
        }

        var previousCharacter = CurrentCharacter;
        try
        {
            var characterNode = GetCharacterNode(characterId);
            CurrentCharacter = new Character(characterNode, IdNameLookup);
            CharacterCache.Add(characterId, CurrentCharacter);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            CurrentCharacter = previousCharacter;
            return false;
        }
    }

    public string GetCharacterName(string characterId)
    {
        return IdNameLookup[characterId];
    }
}