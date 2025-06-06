using System.Xml.Linq;
using LTSaveEd.Models;
using LTSaveEd.Models.ModEditor;
using Microsoft.AspNetCore.Components;

namespace LTSaveEd.Layout;

public abstract class BaseModEditorPage : ComponentBase
{
    protected const int TooltipDelay = 500; // Delay for tooltips in milliseconds
    
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected ApplicationState ApplicationState { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        ApplicationState.UpdateLocation(NavigationManager);
        ApplicationState.SaveModDataHandler = SaveModData;
        ApplicationState.LoadModDataHandler = LoadModDataHandler;
    }

    private async Task<MemoryStream> SaveModData()
    {
        var mod = GetMod();
        var memoryStream = new MemoryStream();
        // TODO: Figure out if the added whitespace around CDATA values cause issues
        await mod.Root.SaveAsync(memoryStream, SaveOptions.None, CancellationToken.None);
        memoryStream.Position = 0;
        return memoryStream;
    }

    protected abstract bool LoadModDataHandler(XDocument doc);
    
    protected abstract Mod GetMod();
}