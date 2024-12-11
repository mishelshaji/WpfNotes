using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ValidationUsingINotifyDataErrorInfo.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = new();

    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
            ValidateName();
        }
    }

    private string _email;

    [Required(ErrorMessage = "Email is required")]
    [MinLength(5, ErrorMessage = "Email too short")]
    [MaxLength(50, ErrorMessage = "Email too long")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
            ValidateEmail();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ValidateName()
    {
        var nameValidationErrors = new List<string>();
        if(string.IsNullOrWhiteSpace(Name))
            nameValidationErrors.Add("Name should not be empty.");
        if (Name.Length < 3)
            nameValidationErrors.Add("Name too short.");
        if (Name.Length > 25)
            nameValidationErrors.Add("Name too long.");
        
        if(nameValidationErrors.Any())
            _errors[nameof(Name)] = nameValidationErrors;
        else
            _errors.Remove(nameof(Name));

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Name)));
    }

    private void ValidateEmail()
    {
        var context = new ValidationContext(this){ MemberName = nameof(Email) };
        var results = new List<ValidationResult>();
        Validator.TryValidateProperty(Email, context, results);
        var emailValidationErrors = results.Select(r => r.ErrorMessage).ToList();
        
        if(emailValidationErrors.Any())
            _errors[nameof(Email)] = emailValidationErrors;
        else
            _errors.Remove(nameof(Email));

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Email)));
    }

    public IEnumerable GetErrors(string? propertyName)
    {
        return _errors.ContainsKey(propertyName)? _errors[propertyName] : null;
    }

    public bool HasErrors => _errors.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
