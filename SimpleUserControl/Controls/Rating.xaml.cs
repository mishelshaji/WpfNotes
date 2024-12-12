using System.Windows;
using System.Windows.Controls;

namespace SimpleUserControl.Controls;

public partial class Rating : UserControl
{
    public static readonly DependencyProperty ValueProperty = 
        DependencyProperty.Register(
            "Value", 
            typeof(int), 
            typeof(Rating), 
            new PropertyMetadata(default(int), PropertyChangedCallback));

    private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (Rating)d;
        // control.Slider.Value = (int)e.NewValue;
    }


    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    
    public Rating()
    {
        InitializeComponent();
    }
}
