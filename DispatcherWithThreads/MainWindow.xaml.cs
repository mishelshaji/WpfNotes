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

namespace DispatcherWithThreads;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var t = new Thread(DoThis);
        t.Start();
    }

    private void DoThis()
    {
        Thread.Sleep(5000);
        Dispatcher.Invoke(() =>
        {
            TxtMessage.Text = "Text updated after 5 seconds.";
        });
    }
}
