using LTSaveEd.Models;
using LTSaveEd.Models.CharacterModel;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public abstract class TabViewModel : ReactiveObject
{
    protected static SaveFileData SaveFileData => SaveFileData.savefile;
    protected static Character Character => SaveFileData.currentCharacter;
    public abstract void PopulateTab();
}