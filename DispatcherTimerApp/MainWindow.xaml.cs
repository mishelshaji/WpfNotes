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
using System.Windows.Threading;

namespace DispatcherTimerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _timer = new DispatcherTimer();
    public MainWindow()
    {
        InitializeComponent();
        _timer.Tick += TimerOnTick;
    }

    private void TimerOnTick(object? sender, EventArgs e)
    {
        TxtClock.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    private void BtnStart_OnClick(object sender, RoutedEventArgs e)
    {
        _timer.Interval = TimeSpan.FromSeconds(5);
        _timer.Start();
    }

    private void BtnStop_OnClick(object sender, RoutedEventArgs e)
    {
        _timer.Stop();
    }
}
