using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValidationUsingINotifyDataErrorInfo.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
            ValidateProperty();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public IEnumerable GetErrors(string? propertyName)
    {
        _errors.TryGetValue(propertyName, out var errors);
        return errors;
    }

    private void ValidateProperty([CallerMemberName]string propertyName = null)
    {
        var errors = new List<string>();
        if (propertyName == nameof(Name))
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("Invalid Name");
            }
        }

        if (errors.Any())
        {
            _errors[propertyName] = errors;
        }
        else
        {
            _errors.Remove(propertyName);
        }
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public bool HasErrors => _errors.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
