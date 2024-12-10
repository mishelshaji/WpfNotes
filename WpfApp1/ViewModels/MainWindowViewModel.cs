﻿using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel: INotifyPropertyChanged, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
            ValidateProperty();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public IEnumerable GetErrors(string? propertyName)
    {
        // _errors.TryGetValue(propertyName, out var errors);
        // return errors;
        if (_errors.ContainsKey(propertyName))
        {
            return _errors[propertyName];
        }

        return null;
    }

    public bool HasErrors => _errors.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    private void ValidateProperty([CallerMemberName] string propertyName = null)
    {
        var errors = new List<string>();
        if (propertyName == nameof(Name))
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("Name should not be empty.");
            }
        }

        if (errors.Any())
        {
            _errors[propertyName] = errors;
        }
        else
        {
            _errors.Remove(propertyName);
        }
        
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
