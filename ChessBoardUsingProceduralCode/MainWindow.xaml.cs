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

namespace ChessBoardUsingProceduralCode;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        int size = 8;
        var chessBoardGrid = new Grid();

        for (int i = 0; i < size; i++)
        {
            var row = new RowDefinition();
            row.Height = new GridLength(1, GridUnitType.Star);
            chessBoardGrid.RowDefinitions.Add(row);
            
            var column = new ColumnDefinition();
            column.Width = new GridLength(1, GridUnitType.Star);
            chessBoardGrid.ColumnDefinitions.Add(column);
        }
        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var square = new Rectangle();
                square.Fill = i % 2 == j % 2 ? Brushes.White : Brushes.Black;
                Grid.SetRow(square, i);
                Grid.SetColumn(square, j);
                chessBoardGrid.Children.Add(square);
            }
        }

        Content = chessBoardGrid;
    }
}
