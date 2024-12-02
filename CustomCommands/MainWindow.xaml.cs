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
using CustomCommands.Commands;

namespace CustomCommands;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool isLocked = false;
    public RelayCommand ClickCommand { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        ClickCommand = new RelayCommand(Execute, CanExecute);
    }

    private bool CanExecute(object? arg)
    {
        return !isLocked;
    }
    
    private void Execute(object? o)
    {
        MessageBox.Show("Hello");
    }

    private void ButtonLock_OnClick(object sender, RoutedEventArgs e)
    {
        isLocked = true;
        ClickCommand.OnCanExecuteChanged();
    }

    private void ButtonUnlock_OnClick(object sender, RoutedEventArgs e)
    {
        isLocked = false;
        ClickCommand.OnCanExecuteChanged();
    }
}
