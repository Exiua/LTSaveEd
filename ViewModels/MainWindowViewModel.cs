using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Avalonia.Controls;
using LTSaveEd.Models;
using LTSaveEd.Views;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public static MainWindow Window { private get; set; } = null!;

    private static SaveFileData SaveFileData => SaveFileData.savefile;

    private readonly List<TabViewModel> _tabs;

    private bool _fileLoaded;
    
    public CoreTabViewModel CoreTabViewModel { get; }

    public MainWindowViewModel()
    {
        _tabs = new List<TabViewModel>();
        CoreTabViewModel = new CoreTabViewModel();
        _tabs.Add(CoreTabViewModel);
    }
    
    public async void LoadFile()
    {
        var filepath = await Window.GetReadableFilepath();
        if (filepath is null)
        {
            return;
        }

        _fileLoaded = true;
        SaveFileData.LoadData(filepath); // Reads data from file
        LoadData();                      // Updates UI with data
    }

    public async void SaveFile()
    {
        if (!_fileLoaded)
        {
            return;
        }
        
        var filepath = await Window.GetWriteableFilepath();
        if (filepath is null)
        {
            return;
        }
        
        SaveFileData.SaveData(filepath);
    }

    public void OverwriteFile()
    {
        if (!_fileLoaded)
        {
            return;
        }
        
        
        SaveFileData.SaveData(Window.Filepath);
    }

    private void LoadData()
    {
        foreach (var tab in _tabs)
        {
            tab.PopulateTab();
        }
    }
}