using System.Windows;
using System.Windows.Controls;

namespace PasswordCheckerUserControl.Controls;

public partial class PasswordGroup : UserControl
{
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
        nameof(Password), typeof(string), typeof(PasswordGroup), new PropertyMetadata(default(string)));
    
    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set { SetValue(PasswordProperty, value); }
    }

    public static readonly DependencyProperty RequireNumbersProperty = DependencyProperty.Register(
        nameof(RequireNumbers), typeof(bool), typeof(PasswordGroup), new PropertyMetadata(default(bool)));

    public bool RequireNumbers
    {
        get { return (bool)GetValue(RequireNumbersProperty); }
        set { SetValue(RequireNumbersProperty, value); }
    }

    public static readonly DependencyProperty RequireUpperCaseProperty = DependencyProperty.Register(
        nameof(RequireUpperCase), typeof(bool), typeof(PasswordGroup), new PropertyMetadata(default(bool)));

    public bool RequireUpperCase
    {
        get { return (bool)GetValue(RequireUpperCaseProperty); }
        set { SetValue(RequireUpperCaseProperty, value); }
    }

    public static readonly DependencyProperty RequireLowerCaseProperty = DependencyProperty.Register(
        nameof(RequireLowerCase), typeof(bool), typeof(PasswordGroup), new PropertyMetadata(default(bool)));

    public bool RequireLowerCase
    {
        get { return (bool)GetValue(RequireLowerCaseProperty); }
        set { SetValue(RequireLowerCaseProperty, value); }
    }

    public static readonly DependencyProperty MinimumLengthProperty = DependencyProperty.Register(
        nameof(MinimumLength), typeof(int), typeof(PasswordGroup), new PropertyMetadata(default(int)));

    public int MinimumLength
    {
        get { return (int)GetValue(MinimumLengthProperty); }
        set { SetValue(MinimumLengthProperty, value); }
    }

    public static readonly DependencyProperty MaximumLengthProperty = DependencyProperty.Register(
        nameof(MaximumLength), typeof(int), typeof(PasswordGroup), new PropertyMetadata(default(int)));

    public int MaximumLength
    {
        get { return (int)GetValue(MaximumLengthProperty); }
        set { SetValue(MaximumLengthProperty, value); }
    }

    private string PasswordFieldValue { get; set; }
    private string ConfirmPasswordFieldValue { get; set; }
    
    public PasswordGroup()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void TxtPassword_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        PasswordFieldValue = TxtPassword.Text.Trim();
        ValidateAndBindPassword();
    }

    private void TxtConfirmPassword_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        ConfirmPasswordFieldValue = TxtConfirmPassword.Text.Trim();
        ValidateAndBindPassword();
    }

    private void ValidateAndBindPassword()
    {
        if (
            PasswordFieldValue != ConfirmPasswordFieldValue ||
            PasswordFieldValue.Length < MinimumLength ||
            PasswordFieldValue.Length > MaximumLength ||
            (RequireNumbers && !PasswordFieldValue.Any(char.IsDigit)) ||
            (RequireUpperCase && !PasswordFieldValue.Any(char.IsUpper)) ||
            (RequireLowerCase && !PasswordFieldValue.Any(char.IsLower)))
        {
            Password = string.Empty;
            return;
        }
        
        Password = PasswordFieldValue;
    }
}
