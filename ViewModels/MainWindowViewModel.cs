using System.Diagnostics;
using LTSaveEd.Models;
using LTSaveEd.Views;
using LTSaveEd.Utility;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public static MainWindow Window { private get; set; } = null!;

    private static SaveFile SaveFile => SaveFile.savefile;

    public CoreTabViewModel CoreTabViewModel { get; }

    public MainWindowViewModel()
    {
        CoreTabViewModel = new CoreTabViewModel();
    }
    
    public async void LoadFile()
    {
        var filepath = await Window.GetFilepath();
        if (filepath is null)
        {
            return;
        }

        SaveFile.LoadData(filepath);
        LoadData();
    }

    private void LoadData()
    {
        CoreTabViewModel.PopulateTab();
    }
}