using System.Xml.Linq;
using LTSaveEd.Models;
using LTSaveEd.Models.ModEditor;
using Microsoft.AspNetCore.Components;

namespace LTSaveEd.BasePages;

public abstract class BaseModEditorPage : ComponentBase
{
    protected const int TooltipDelay = 500; // Delay for tooltips in milliseconds
    
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected ApplicationState ApplicationState { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        // Set the application state location and handlers
        ApplicationState.UpdateLocation(NavigationManager);
        ApplicationState.SaveModDataHandler = SaveModData;
        ApplicationState.LoadModDataHandler = LoadModDataHandler;
        // It's fine not to redirect to home as each page is independent (e.g., each handles its own mod type)
    }

    /// <summary>
    ///     Serialize the current mod data xml to a MemoryStream.
    /// </summary>
    /// <returns>A MemoryStream containing the serialized XML data.</returns>
    private async Task<MemoryStream> SaveModData()
    {
        var mod = GetMod();
        var memoryStream = new MemoryStream();
        // TODO: Figure out if the added whitespace around CDATA values cause issues
        await mod.Root.SaveAsync(memoryStream, SaveOptions.None, CancellationToken.None);
        memoryStream.Position = 0;
        return memoryStream;
    }

    /// <summary>
    ///     Load mod data from the provided XDocument.
    /// </summary>
    /// <param name="doc">The XDocument containing the xml mod data to load.</param>
    /// <returns>>True if loading was successful, false otherwise.</returns>
    protected abstract bool LoadModDataHandler(XDocument doc);
    
    /// <summary>
    ///     Get the current mod instance (ColorMod, ClothingMod, etc.).
    /// </summary>
    /// <returns>The current mod instance.</returns>
    protected abstract Mod GetMod();
}