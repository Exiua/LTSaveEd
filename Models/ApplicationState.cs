using System.Xml.Linq;
using LTSaveEd.Models.CharacterExporter;
using LTSaveEd.Models.Enums;
using Microsoft.AspNetCore.Components;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LTSaveEd.Models;

public class ApplicationState
{
    private static readonly ILogger Logger = Log.ForContext<ApplicationState>();
    
    public SaveData SaveData { get; set; } = new();
    public ExportEditor ExportEditor { get; set; } = new(); 
    public ApplicationStateLocation Location { get; set; } = ApplicationStateLocation.SaveEditor;
    public Func<Task<MemoryStream>>? SaveModDataHandler { get; set; }
    public Func<XDocument, bool>? LoadModDataHandler { get; set; }
    
    public event Action? LocationChanged;

    public void UpdateLocation(NavigationManager navigationManager)
    {
        var path = navigationManager.Uri;
        if (path.Contains("/mod-editor/"))
        {
            Location = ApplicationStateLocation.ModEditor;
        }
        else if (path.EndsWith("/mod-editor"))
        {
            Location = ApplicationStateLocation.ModEditorHome;
        }
        else if (path.Contains("/character-exporter"))
        {
            Location = ApplicationStateLocation.CharacterExporter;
        }
        else
        {
            Location = ApplicationStateLocation.SaveEditor;
        }
        
        LocationChanged?.Invoke();
    }

    public async Task<MemoryStream> SaveMod()
    {
        if (SaveModDataHandler is null)
        {
            throw new InvalidOperationException("SaveModDataHandler is not set.");
        }

        var memoryStream = await SaveModDataHandler();
        memoryStream.Position = 0;
        return memoryStream;
    }

    public async Task<bool> LoadMod(Stream stream)
    {
        try
        {
            var doc = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
            if (LoadModDataHandler is null)
            {
                throw new InvalidOperationException("LoadModDataHandler is not set.");
            }
            
            var initialized = LoadModDataHandler(doc);
            return initialized;
        }
        catch (Exception e)
        {
            #if DEBUG
            Logger.Error(e, "Error loading mod data");
            #endif
            return false;
        }
    }
}