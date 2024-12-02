using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValueConverter;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private string _selectedGender;

    public string SelectedGender
    {
        get => _selectedGender;
        set
        {
            _selectedGender = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName]string propertyName=null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
