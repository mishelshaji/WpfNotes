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

namespace VisualStatesAndTransition;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
    {
        VisualStateManager.GoToState(this, "MouseOver", true);
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        VisualStateManager.GoToState(this, "Pressed", true);
    }

    private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        VisualStateManager.GoToState(this, "Normal", true);
    }
}
