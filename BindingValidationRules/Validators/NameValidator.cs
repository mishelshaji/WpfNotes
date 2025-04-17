using System.Globalization;
using System.Windows.Controls;

namespace BindingValidationRules.Validators;

public class NameValidator: ValidationRule
{
    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        if (value is null)
        {
            return new ValidationResult(false, "Name should not be empty.");
        }
        var data = (string)value;
        if (data.Length < 5)
        {
            return new ValidationResult(false, "Name too short.");
        }
        if (data.Length > 25)
        {
            return new ValidationResult(false, "Name too long.");
        }
    
        return new ValidationResult(true, null);
    }
}
