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
using ViewModelBinding.ViewModels;

namespace ViewModelBinding;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _model;
    public MainWindow()
    {
        _model = new MainWindowViewModel();
        InitializeComponent();
        DataContext = _model;
    }

    private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
    {
        var time = DateTime.Now;
        _model.Time = time.ToString();
        _model.Seconds = time.Second;
    }
}
