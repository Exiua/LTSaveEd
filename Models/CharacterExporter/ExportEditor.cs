using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterExporter;

public class ExportEditor
{
    internal XDocument ExportedCharacterXml { get; set; } = null!;

    public Character Character { get; set; } = null!;
    public bool Initialized { get; private set; }

    public async Task<bool> Load(Stream data)
    {
        ExportedCharacterXml = await XDocument.LoadAsync(data, LoadOptions.None, CancellationToken.None);
        return await LoadCharacter();
    }

    public Task<bool> LoadDefault()
    {
        ExportedCharacterXml = EmbeddedXmlLoader.LoadXmlFromResource("LTSaveEd.Resources.angel.xml");
        return LoadCharacter();
    }

    private Task<bool> LoadCharacter()
    {
        var exportedCharacterElement = ExportedCharacterXml.Element("exportedCharacter");
        var characterElement = exportedCharacterElement?.Element("character");
        if (characterElement is null)
        {
            return Task.FromResult(false);
        }
        
        Character = new Character(characterElement, new Dictionary<string, string>());
        Initialized = true;
        
        return Task.FromResult(true);
    }
}