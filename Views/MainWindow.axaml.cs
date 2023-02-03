using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using LTSaveEd.ViewModels;

namespace LTSaveEd.Views;

public partial class MainWindow : Window
{
    public string Filepath { get; set; } = ".";
    
    public MainWindow()
    {
        MainWindowViewModel.Window = this;
        InitializeComponent();
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
}