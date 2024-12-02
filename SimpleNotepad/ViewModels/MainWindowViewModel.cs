using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleNotepad.ViewModels;

public class MainWindowViewModel: ViewModelBase
{
    private string _fileName;

    public string FileName
    {
        get => _fileName;
        set
        {
            _fileName = value;
            OnPropertyChanged();
        }
    }

    private string _content;

    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged();
        }
    }
}
