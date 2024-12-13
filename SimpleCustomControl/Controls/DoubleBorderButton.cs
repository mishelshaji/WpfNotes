using System.Windows;
using System.Windows.Controls;

namespace SimpleCustomControl.Controls;

public class DoubleBorderButton: ContentControl
{
    public DoubleBorderButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DoubleBorderButton),
            new FrameworkPropertyMetadata(typeof(DoubleBorderButton)));
    }
}
