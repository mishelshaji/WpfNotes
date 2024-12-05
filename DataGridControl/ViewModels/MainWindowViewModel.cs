using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DataGridControl.Commands;
using DataGridControl.Models;

namespace DataGridControl.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged
{
    private User _selectedItem;

    public User SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
            DeleteCommand.OnCanExecuteChanged();
        }
    }

    public ObservableCollection<User> Users { get; set; }

    public RelayCommands DeleteCommand { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindowViewModel()
    {
        Users = new ObservableCollection<User>()
        {
            new User() { Id = 1, Name = "User 1", Email = "email1@.com" },
            new User() { Id = 2, Name = "User 2", Email = "email2@.com" },
            new User() { Id = 3, Name = "User 3", Email = "email3@.com" },
        };
        DeleteCommand = new RelayCommands(DeleteCommandHandler, CanDeleteCommandHandler);
    }
    
    private void DeleteCommandHandler()
    {
        var confirm = MessageBox.Show(
            "Are you sure you want to delete this user?",
            "Delete User",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.No)
        {
            return;
        }
        Users.Remove(SelectedItem);
    }

    private bool CanDeleteCommandHandler()
    {
        return SelectedItem != null;
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
