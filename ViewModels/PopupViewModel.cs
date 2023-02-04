using LTSaveEd.Views;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class PopupViewModel : ReactiveObject
{
    private string _message;

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            this.RaisePropertyChanged();
        }
    }
    
    public bool Result { get; set; }

    public PopupViewModel()
    {
        _message = "";
    }
    
    public PopupViewModel(string message)
    {
        _message = message;
    }

    public void SetTrue()
    {
        Result = true;
        PopupWindow.Window.Close();
    }
    
    public void SetFalse()
    {
        Result = false;
        PopupWindow.Window.Close();
    }
}