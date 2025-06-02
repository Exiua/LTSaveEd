using LTSaveEd.Models.Enums;
using Microsoft.AspNetCore.Components;

namespace LTSaveEd.Models;

public class ApplicationState
{
    public SaveData SaveData { get; set; } = new();
    public ApplicationStateLocation Location { get; set; } = ApplicationStateLocation.SaveEditor;

    public void UpdateLocation(NavigationManager navigationManager)
    {
        var path = navigationManager.Uri;
        Location = path.Contains("/mod-editor/") ? ApplicationStateLocation.ModEditor : ApplicationStateLocation.SaveEditor;
    }
}