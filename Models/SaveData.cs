using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

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
                ResetCaches();
            }
        }
    }

    public Character CurrentCharacter { get; private set; }= null!;
    public ValueDisplayPair<string> CurrentCharacterIdNamePair { get; private set; } = null!;
    public World WorldData { get; private set; } = null!;
    public Offsprings Offsprings { get; private set; } = null!;
    
    internal XDocument SaveDataXml { get; private set; } = null!;

    public List<ValueDisplayPair<string>> CharacterIds { get; } = [new("Player", "PlayerCharacter")];
    private Dictionary<string, Character> CharacterCache { get; } = new();
    private Dictionary<string, string> IdNameLookup { get; } = new();
    private Dictionary<string, XElement> IdCharacterLookup { get; } = new();
    
    
    public async Task<bool> Initialize(Stream data)
    {
        Initialized = false;
        SaveDataXml = await XDocument.LoadAsync(data, LoadOptions.None, CancellationToken.None);
        var coreInfoNode = SaveDataXml.Descendants("coreInfo").First();
        var dialogueFlagsNode = SaveDataXml.Descendants("dialogueFlags").First();
        WorldData = new World(coreInfoNode, dialogueFlagsNode);
        Offsprings = new Offsprings(SaveDataXml.Descendants("OffspringSeed"), GetCharacterNode);
        PopulateCharacterIds();
        Initialized = LoadCharacter(CharacterIds[0]);
        return Initialized;
    }

    private void ResetCaches()
    {
        CharacterIds.Clear();
        CharacterIds.Add(new ValueDisplayPair<string>("Player", "PlayerCharacter"));
        CharacterCache.Clear();
        IdNameLookup.Clear();
        IdCharacterLookup.Clear();
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
                <= 60 => nameElement.Attribute("nameAndrogynous")!.Value,
                > 60 => nameElement.Attribute("nameFeminine")!.Value
            };
            var idValue = id.Value;
            CharacterIds.Add(new ValueDisplayPair<string>(name, idValue));
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
    
    public bool LoadCharacter(ValueDisplayPair<string> characterIdPair)
    {
        var characterId = characterIdPair.Value;
        if (CharacterCache.TryGetValue(characterId, out var character))
        {
            CurrentCharacter = character;
            return true;
        }

        // ReSharper disable once RedundantAssignment
        var previousCharacter = CurrentCharacter;
        try
        {
            var characterNode = GetCharacterNode(characterId);
            CurrentCharacter = new Character(characterNode, IdNameLookup);
            CurrentCharacterIdNamePair = characterIdPair;
            CharacterCache.Add(characterId, CurrentCharacter);
            return true;
        }
        catch (Exception e)
        {
            #if DEBUG
            Console.WriteLine(e);
            throw;
            #else
            Console.WriteLine(e);
            CurrentCharacter = previousCharacter;
            return false;
            #endif
        }
    }

    public void DeleteCurrentCharacter()
    {
        var characterIndex = CharacterIds.IndexOf(CurrentCharacterIdNamePair);
        var deletedCharacterId = CurrentCharacterIdNamePair.Value;
        var currentCharacterNpcNode = GetCharacterNode(deletedCharacterId).Parent!;
        currentCharacterNpcNode.Remove();
        CharacterIds.RemoveAt(characterIndex);
        CharacterCache.Remove(deletedCharacterId);
        IdNameLookup.Remove(deletedCharacterId);
        IdCharacterLookup.Remove(deletedCharacterId);
        var success = LoadCharacter(CharacterIds[--characterIndex]); // Decrement index first, then retrieve
        while (!success)
        {
            characterIndex--;
            if (characterIndex < 0) // Should never happen since player should always be loadable or save is modded
            {
                throw new Exception("Failed to load characters");
            }
            
            success = LoadCharacter(CharacterIds[characterIndex]);
        }
    }
    
    public string GetCharacterName(string characterId)
    {
        return IdNameLookup[characterId];
    }

    public XElement GetElement(string elementName)
    {
        return SaveDataXml.Descendants(elementName).First();
    }
}