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

namespace EventBubbling;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Button click handler.");
    }

    private void BorderButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Button click handler by border.");
        // e.Handled = true;
    }

    private void StackPanelButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Button click handler by stack panel.");
        // e.Handled = true;
    }
}
