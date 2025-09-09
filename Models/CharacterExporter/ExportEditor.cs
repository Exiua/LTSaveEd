using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterExporter;

public class ExportEditor
{
    internal XDocument ExportedCharacterXml { get; set; } = null!;

    public Character Character { get; set; } = null!;
    public bool Initialized { get; private set; }

    public async Task<bool> Initialize(Stream data)
    {
        ExportedCharacterXml = await XDocument.LoadAsync(data, LoadOptions.None, CancellationToken.None);
        // TODO: May want to look into allowing the Character ctor to use null for the dictionary
        Character = new Character(ExportedCharacterXml.Root!, new Dictionary<string, string>());

        return true;
    }
}