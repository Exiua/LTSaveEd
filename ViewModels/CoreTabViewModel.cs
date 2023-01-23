using System.Diagnostics;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class CoreTabViewModel : TabViewModel
{
    private string _characterId = "";
    public string CharacterId
    {
        get => _characterId;
        set => this.RaiseAndSetIfChanged(ref _characterId, value);
    }

    public override void PopulateTab()
    {
        PopulateCharacterComboBox();
        CharacterId = SaveFile.GetDescendantByName(SaveFile.currentCharacter, "id").FirstAttribute?.Value ?? "NULL";
    }
    
    private void PopulateCharacterComboBox()
    {
        var npcs = SaveFile.GetNpcList();
        //npcs.Print();
        Debug.WriteLine("Populated Character ComboBox");
    }
}