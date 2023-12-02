using System.Xml.Linq;

namespace LTSaveEd.Models;

public class SaveData
{
    public bool Initialized { get; private set; }

    private XDocument SaveDataXml { get; set; } = null!;

    public List<string> CharacterIds { get; } = new(){ "PlayerCharacter" };
    
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
    }
}