using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataAnnotationsValidation.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged, IDataErrorInfo
{
    private string _name;

    [Required]
    [MinLength(5, ErrorMessage = "Name is too short.")]
    [MaxLength(25)]
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string Error { get; }
    
    public string this[string columnName]
    {
        get
        {
            var context = new ValidationContext(this) { MemberName = columnName };
            var results = new List<ValidationResult>();
            var property = this.GetType().GetProperty(columnName);
            var propertyValue = property.GetValue(this);
            var isValid = Validator.TryValidateProperty(propertyValue, context, results);
            return isValid? null : results.First().ErrorMessage;
        }
    }
}
