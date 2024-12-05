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

namespace GridViewControl;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly List<User> _users;
    public MainWindow()
    {
        InitializeComponent();
        _users = new List<User>()
        {
            new User { Id = 1, Name = "User 1", Email = "user1@mail.com" },
            new User { Id = 2, Name = "User 2", Email = "user2@mail.com" },
            new User { Id = 3, Name = "User 3", Email = "user3@mail.com" },
            new User { Id = 4, Name = "User 4", Email = "user4@mail.com" },
            new User { Id = 5, Name = "User 5", Email = "user5@mail.com" },
        };
        UserListView.ItemsSource = _users;
    }
}
