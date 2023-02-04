using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LTSaveEd.Views;

public partial class PopupWindow : Window
{
    public static PopupWindow Window { get; private set; } = null!;
    
    public PopupWindow()
    {
        Window = this;
        InitializeComponent();
        #if DEBUG
        this.AttachDevTools();
        #endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}