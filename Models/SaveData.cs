using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class SaveData
{
    public bool Initialized { get; private set; }
    public Character CurrentCharacter { get; private set; }= null!;

    internal XDocument SaveDataXml { get; private set; } = null!;

    private List<string> CharacterIds { get; } = new(){ "PlayerCharacter" };
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
            CharacterIds.Add(id.Value);
        }
        Console.WriteLine(CharacterIds.ToFormattedString());
        LoadCharacter(CharacterIds[0]);
    }

    private void LoadCharacter(string characterId)
    {
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