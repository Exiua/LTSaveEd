using System.Collections.Generic;
using LTSaveEd.Models;
using LTSaveEd.Views;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public static MainWindow Window { private get; set; } = null!;

    private static SaveFile SaveFile => SaveFile.savefile;

    private readonly List<TabViewModel> _tabs;

    public CoreTabViewModel CoreTabViewModel { get; }

    public MainWindowViewModel()
    {
        _tabs = new List<TabViewModel>();
        CoreTabViewModel = new CoreTabViewModel();
        _tabs.Add(CoreTabViewModel);
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
        foreach (var tab in _tabs)
        {
            tab.PopulateTab();
        }
    }
}