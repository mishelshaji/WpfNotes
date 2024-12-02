using System.Globalization;
using System.Windows.Data;

namespace ValueConverter;

public class GenderConverter: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return false;
        }

        return value.ToString() == parameter?.ToString();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }
        return (bool)value ? parameter?.ToString() : null;
    }
}
