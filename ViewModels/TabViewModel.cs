using LTSaveEd.Models;
using LTSaveEd.Models.CharacterModel;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public abstract class TabViewModel : ReactiveObject
{
    protected static SaveFile SaveFile => SaveFile.savefile;
    protected static Character Character => SaveFile.currentCharacter;
    
    public abstract void PopulateTab();
}