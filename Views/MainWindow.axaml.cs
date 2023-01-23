using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using LTSaveEd.ViewModels;

namespace LTSaveEd.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        MainWindowViewModel.Window = this;
        InitializeComponent();
    }

    public async Task<string?> GetFilepath()
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
        
        Debug.WriteLine("Filepath: " + string.Join(" ", result));
        return string.Join(" ", result);
    }
}