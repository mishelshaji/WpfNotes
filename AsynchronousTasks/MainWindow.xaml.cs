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

namespace AsynchronousTasks;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var limit = int.Parse(TxtLimit.Text);
        var sum = await CalculateAsync(limit);
        Result.Text = sum.ToString();
    }

    private async Task<int> CalculateAsync(int limit)
    {
        return await Task.Run(() =>
        {
            int res = 0;
            for (int i = 0; i < limit; i++)
            {
                Thread.Sleep(1000);
                res += i;
            }
            return res;
        });
    }
}
