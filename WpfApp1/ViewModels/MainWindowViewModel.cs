using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Commands;
using WpfApp1.Models;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private readonly List<Contact> _contacts;
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            _email = value.ToLower();
            OnPropertyChanged();
        }
    }

    private string _phone;

    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged();
        }
    }

    public string Search { get; set; }
    public ObservableCollection<Contact> Contacts { get; set; }
    public RelayCommand SaveCommand { get; set; }
    public RelayCommand SearchCommand { get; set; }

    public MainWindowViewModel()
    {
        _contacts = new List<Contact>();
        Contacts = new ObservableCollection<Contact>(_contacts);
        SaveCommand = new RelayCommand(HandleSaveCommand);
        SearchCommand = new RelayCommand(HandleSearchCommand);
    }

    private void HandleSearchCommand()
    {
        var result = _contacts
            .Where(i => i.Name.Contains(Search, StringComparison.OrdinalIgnoreCase) || 
                        i.Email.Contains(Search, StringComparison.OrdinalIgnoreCase));
        
        Contacts.Clear();
        foreach (var contact in result)
        {
            Contacts.Add(contact);
        }
    }

    private void HandleSaveCommand()
    {
        var contact = new Contact()
        {
            Name = Name,
            Email = Email,
            Phone = Phone
        };
        _contacts.Add(contact);
        Contacts.Add(contact);

        Name = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
