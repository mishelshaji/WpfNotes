using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModelBinding.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private string _time;

    public string Time
    {
        get => _time;
        set
        {
            _time = value;
            OnPropertyChanged();
        }
    }

    private int _seconds;

    public int Seconds
    {
        get => _seconds;
        set
        {
            _seconds = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
