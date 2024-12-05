using System.Windows.Input;

namespace DataGridControl.Commands;

public class RelayCommands: ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public RelayCommands(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    
    public bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke() ?? true;
    }

    public void Execute(object? parameter)
    {
        _execute();
    }

    public event EventHandler? CanExecuteChanged;

    public virtual void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
