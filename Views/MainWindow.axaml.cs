using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using LTSaveEd.ViewModels;
using ReactiveUI;

namespace LTSaveEd.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public string Filepath { get; set; } = ".";
    
    public MainWindow()
    {
        MainWindowViewModel.Window = this;
        InitializeComponent();
        #if DEBUG
        this.AttachDevTools();
        #endif
    }

    public async Task<string?> GetReadableFilepath()
    {
        var fileExtensions = new List<string> { "xml" };
        var extensionFilter = new FileDialogFilter { Extensions = fileExtensions };
        var dialog = new OpenFileDialog
        {
            AllowMultiple = false,
            Filters = new List<FileDialogFilter> { extensionFilter }
        };
        var result = await dialog.ShowAsync(this);

        if (result is null)
        {
            Debug.WriteLine("Filepath: null");
            return null;
        }

        Filepath = string.Join(" ", result);
        Debug.WriteLine($"Filepath: {Filepath}");
        return Filepath;
    }

    public async Task<string?> GetWriteableFilepath()
    {
        var fileExtensions = new List<string> { "xml" };
        var extensionFilter = new FileDialogFilter { Extensions = fileExtensions };
        var dialog = new SaveFileDialog
        {
            Title = "Save File As...",
            InitialFileName = Path.GetFullPath(Filepath),
            Directory = Path.GetDirectoryName(Filepath),
            Filters = new List<FileDialogFilter> { extensionFilter },
            DefaultExtension = "xml"
        };
        var result = await dialog.ShowAsync(this);

        if (result is null)
        {
            Debug.WriteLine("Filepath: null");
            return null;
        }

        Debug.WriteLine($"Filepath: {result}");
        return result;
    }

    public async Task<bool> GetPopupResponse(string message)
    {
        var popupViewModel = new PopupViewModel(message);
        var dialog = new PopupWindow
        {
            DataContext = popupViewModel,
            Width = 500,
            Height = 150
        };

        await dialog.ShowDialog(this);
        return popupViewModel.Result;
    }
}