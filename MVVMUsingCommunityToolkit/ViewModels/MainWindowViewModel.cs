using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMUsingCommunityToolkit.ViewModels;

public partial class MainWindowViewModel: ObservableObject
{
    [ObservableProperty] private string name;
    [ObservableProperty] private string email;
    [ObservableProperty] private string phone;

    public RelayCommand SaveCommand { get; set; }

    public MainWindowViewModel()
    {
        SaveCommand = new RelayCommand(SaveCommandHandler);
    }

    private void SaveCommandHandler()
    {
        var msg = $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}";
        MessageBox.Show(msg);
    }
}
