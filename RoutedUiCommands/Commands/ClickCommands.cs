using System.Windows.Input;

namespace CustomCommands.Commands;

public class ClickCommands
{
    public static readonly RoutedUICommand ButtonClick = new RoutedUICommand(
        "Click",
        "Click",
        typeof(ClickCommands),
        new InputGestureCollection()
        {
            new KeyGesture(Key.Enter, ModifierKeys.Control)
        });
}
