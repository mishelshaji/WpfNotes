using System.ComponentModel;
using System.Windows;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private BackgroundWorker worker = new BackgroundWorker();
    public MainWindow()
    {
        InitializeComponent();
        worker.DoWork += WorkerOnDoWork;
        worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
    }

    private void WorkerOnRunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        var res = (string)e.Result;
        TxtResult.Text = res;
    }

    private void WorkerOnDoWork(object? sender, DoWorkEventArgs e)
    {
        Thread.Sleep(2000);
        e.Result = "Done";
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        worker.RunWorkerAsync();
    }
}
