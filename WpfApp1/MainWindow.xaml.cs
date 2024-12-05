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

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var grid = new Grid();
        int rows = 3;
        int columns = 3;

        for (int i = 0; i < rows; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        grid.ShowGridLines = true;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                var lbl = new Label();
                lbl.Content = $"Label at row: {r}, column: {c}";
                Grid.SetRow(lbl, r);
                Grid.SetColumn(lbl, c);
                grid.Children.Add(lbl);
            }
        }
        AddChild(grid);
    }
}
