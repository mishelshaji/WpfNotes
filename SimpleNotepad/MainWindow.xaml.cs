using System.IO;
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
using Microsoft.Win32;
using SimpleNotepad.ViewModels;

namespace SimpleNotepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _model;
    public MainWindow()
    {
        InitializeComponent();
        _model = new MainWindowViewModel();
        DataContext = _model;
    }

    private void Open_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }

    private void Open_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "Text Files|*.txt|All Files|*.*";

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        _model.FileName = dialog.FileName;
        _model.Content = File.ReadAllText(dialog.FileName);
    }

    private void Save_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = _model.FileName != null;
    }

    private void Save_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        File.WriteAllText(_model.FileName, _model.Content);
        MessageBox.Show("File Saved", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
