using System.Windows;
using System.Windows.Controls;

namespace PagesAndFrames.Pages;

public partial class Page2 : Page
{
    public Page2()
    {
        InitializeComponent();
    }

    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
    }
}
