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

namespace EventTunneling;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void StackPanel_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Event handled by stack panel");
        // e.Handled = true;
    }

    private void Button_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Event handled by button");
    }
}
