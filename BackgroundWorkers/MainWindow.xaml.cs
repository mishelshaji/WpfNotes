using System.ComponentModel;
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

namespace BackgroundWorkers;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly BackgroundWorker _worker = new BackgroundWorker();
    public MainWindow()
    {
        InitializeComponent();
        _worker.WorkerReportsProgress = true;
        _worker.DoWork += WorkerOnDoWork;
        _worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
        _worker.ProgressChanged += WorkerOnProgressChanged;
    }

    private void WorkerOnProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
        TaskProgress.Value = e.ProgressPercentage;
    }

    private void WorkerOnRunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        TxtResult.Text = e.Result.ToString();
    }

    private void WorkerOnDoWork(object? sender, DoWorkEventArgs e)
    {
        _worker.ReportProgress(0);
        int steps = (int)e.Argument;
        for (int i = 1; i <= steps; i++)
        {
            Thread.Sleep(1000);
            int progressPrecent = (i * 100) / steps;
            _worker.ReportProgress(progressPrecent);
        }
        e.Result = $"Task completed at: {DateTime.Now}.";
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        int steps = int.Parse(TxtSteps.Text);
        _worker.RunWorkerAsync(steps);
    }
}
