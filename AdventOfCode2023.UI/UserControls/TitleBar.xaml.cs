using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FontAwesome.Sharp;

namespace AdventOfCode2023.UI.UserControls;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();
    }

    private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        Window.GetWindow(this)!.WindowState = WindowState.Minimized;
    }
    
    private void MaximizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this)!.WindowState == WindowState.Maximized)
        {
            Window.GetWindow(this)!.WindowState = WindowState.Normal;
            MaximizeIcon.Icon = IconChar.WindowMaximize;
        }
        else
        {
            Window.GetWindow(this)!.WindowState = WindowState.Maximized;
            MaximizeIcon.Icon = IconChar.WindowRestore;
        }
    }
    
    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void TopAppBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Window.GetWindow(this)!.DragMove();
    }
}