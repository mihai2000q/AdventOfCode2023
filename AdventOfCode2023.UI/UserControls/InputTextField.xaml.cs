using System.Windows;
using System.Windows.Controls;

namespace AdventOfCode2023.UI.UserControls;

public partial class InputTextField : UserControl
{
    public static readonly DependencyProperty InputTextProperty = 
        DependencyProperty.Register(nameof(InputText), typeof(string), typeof(InputTextField));

    public string InputText
    {
        get => (string)GetValue(InputTextProperty);
        set => SetValue(InputTextProperty, value);
    }
    
    public InputTextField()
    {
        InitializeComponent();
    }

    private void InputTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Placeholder.Visibility = string.IsNullOrEmpty(InputTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
    }
}