using System.Windows;
using System.Windows.Controls;

namespace UserControlWithDependencyProperties.Controls;

public partial class Rating : UserControl
{
    public static readonly DependencyProperty TextProperty = 
        DependencyProperty.Register(
            nameof(Text), 
            typeof(string), 
            typeof(Rating), 
            new PropertyMetadata(default(string)));

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly DependencyProperty ValueProperty = 
        DependencyProperty.Register(
            nameof(Value), 
            typeof(int), 
            typeof(Rating), 
            new PropertyMetadata(1, PropertyChangedCallback));

    private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var userControl = (Rating)d;
        if (e.Property.Name == nameof(Value))
        {
            var value = (int)e.NewValue;
            if (value < 0 || value > 5)
            {
                userControl.Value = 1;
            }
        }
    }

    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    
    public Rating()
    {
        InitializeComponent();
        DataContext = this;
    }
}
