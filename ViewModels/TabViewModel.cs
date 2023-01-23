using LTSaveEd.Models;
using LTSaveEd.Views;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public abstract class TabViewModel : ReactiveObject
{
    protected static SaveFile SaveFile => SaveFile.savefile;
    
    public abstract void PopulateTab();
}