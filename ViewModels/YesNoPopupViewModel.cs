using LTSaveEd.Views;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class YesNoPopupViewModel : ReactiveObject
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

    public YesNoPopupViewModel()
    {
        _message = "";
    }
    
    public YesNoPopupViewModel(string message)
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