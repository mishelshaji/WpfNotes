using System.Windows.Input;

namespace RoutedCommands;

public class CustomCommands
{
    public static readonly RoutedCommand Click = new RoutedCommand();
    public static readonly RoutedCommand Reopen = new RoutedCommand();
}
