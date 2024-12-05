using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckboxControl;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Checkbox was checked.");
    }

    private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Checkbox was unchecked.");
    }

    private void ToggleButton_OnIndeterminate(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Checkbox is in indeterminate state.");
    }
}
