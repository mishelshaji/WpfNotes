using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ShapeRender.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private int _height;

    public int Height
    {
        get => _height;
        set
        {
            if (value == _height) return;
            _height = value;
            CalculateResult();
            OnPropertyChanged();
        }
    }

    private int _width;

    public int Width
    {
        get => _width;
        set
        {
            if (value == _width) return;
            _width = value;
            CalculateResult();
            OnPropertyChanged();
        }
    }

    private int _borderThickness;

    public int BorderThickness
    {
        get => _borderThickness;
        set
        {
            if (value == _borderThickness) return;
            _borderThickness = value;
            OnPropertyChanged();
        }
    }

    private string _borderColor;

    public string BorderColor
    {
        get => _borderColor;
        set
        {
            if (value == _borderColor) return;
            _borderColor = value;
            OnPropertyChanged();
        }
    }

    private string _fillColor;

    public string FillColor
    {
        get => _fillColor;
        set
        {
            if (value == _fillColor) return;
            _fillColor = value;
            OnPropertyChanged();
        }
    }

    private string _result;

    public string Result
    {
        get => _result;
        set
        {
            if (value == _result) return;
            _result = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindowViewModel()
    {
        var defaultColor = (Application.Current.Resources["Colors"] as string[])[0];
        FillColor = defaultColor;
        BorderColor = defaultColor;
        Height = 50;
        Width = 50;
    }

    private void CalculateResult()
    {
        var format = "The area of {0} is {1}";
        Result = string.Format(format, Height == Width ? "Square" : "Rectangle", Height * Width);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
