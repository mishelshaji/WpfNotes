using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleFiltering.Commands;

namespace SimpleFiltering.ViewModel;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private readonly List<string> _names;
    public ObservableCollection<string> Names { get; set; }

    public RelayCommand SearchCommand { get; set; }
    
    private string _search;
    public string Search
    {
        get => _search;
        set
        {
            _search = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindowViewModel()
    {
        _names = new List<string>()
        {
            "John",
            "Jane",
            "Joe",
            "Jill",
            "Mary",
            "Robert",
            "Andrew",
            "Antony",
        };
        Names = new ObservableCollection<string>(_names);
        SearchCommand = new RelayCommand(HandleSearch);
    }

    private void HandleSearch(object data)
    {
        Names.Clear();
        var filteredNames = _names.Where(x => x.ToLower().Contains(Search?.ToLower() ?? ""));
        foreach (var name in filteredNames)
        {
            Names.Add(name);
        }
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
