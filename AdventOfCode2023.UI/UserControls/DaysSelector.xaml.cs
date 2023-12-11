using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AdventOfCode2023.UI.Helper;
using AdventOfCode2023.UI.Model;

namespace AdventOfCode2023.UI.UserControls;

public partial class DaysSelector : UserControl
{
    public static readonly DependencyProperty DaysProperty = 
        DependencyProperty.Register(nameof(Days), typeof(ObservableCollection<Day>), typeof(DaysSelector));

    public ObservableCollection<Day> Days
    {
        get => (ObservableCollection<Day>)GetValue(DaysProperty);
        set => SetValue(DaysProperty, value);
    }
    
    public static readonly DependencyProperty SelectedDayProperty = 
        DependencyProperty.Register(nameof(SelectedDay), typeof(Day), typeof(DaysSelector));

    public Day SelectedDay
    {
        get => (Day)GetValue(SelectedDayProperty);
        set => SetValue(SelectedDayProperty, value);
    }

    public DaysSelector()
    {
        InitializeComponent();
    }
}