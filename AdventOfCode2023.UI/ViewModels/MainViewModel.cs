using System.Collections.ObjectModel;
using System.Windows;
using AdventOfCode2023.UI.Core;
using AdventOfCode2023.UI.Helper;
using AdventOfCode2023.UI.Model;

namespace AdventOfCode2023.UI.ViewModels;

public class MainViewModel : ObservableObject
{
    private Visibility _isLoading;
    public Visibility IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }
    
    private ObservableCollection<Day> _days;
    public ObservableCollection<Day> Days
    {
        get => _days;
        set
        {
            _days = value;
            OnPropertyChanged();
        }
    }
    
    private Day _selectedDay;
    public Day SelectedDay
    {
        get => _selectedDay;
        set
        {
            _selectedDay = value;
            OnPropertyChanged();
        }
    }
    
    private string _answer1;
    public string Answer1
    {
        get => _answer1;
        private set
        {
            _answer1 = value;
            VisibilityAnswer1 = string.IsNullOrEmpty(value) ? Visibility.Collapsed : Visibility.Visible;
            OnPropertyChanged();
        }
    }
    
    private string _answer2;
    public string Answer2
    {
        get => _answer2;
        private set
        {
            _answer2 = value;
            VisibilityAnswer2 = string.IsNullOrEmpty(value) ? Visibility.Collapsed : Visibility.Visible;
            OnPropertyChanged();
        }
    }
    
    private Visibility _visibilityAnswer1;
    public Visibility VisibilityAnswer1
    {
        get => _visibilityAnswer1;
        private set
        {
            _visibilityAnswer1 = value;
            OnPropertyChanged();
        }
    }
    
    private Visibility _visibilityAnswer2;
    public Visibility VisibilityAnswer2
    {
        get => _visibilityAnswer2;
        private set
        {
            _visibilityAnswer2 = value;
            OnPropertyChanged();
        }
    }
    
    private string _input;
    public string Input
    {
        get => _input;
        set
        {
            _input = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand SubmitCommand { get; }
    
    public MainViewModel()
    {
        // Properties
        _isLoading = Visibility.Collapsed;
        _days = Constants.Days;
        _selectedDay = Days.First();
        _answer1 = string.Empty;
        _answer2 = string.Empty;
        _visibilityAnswer1 = Visibility.Collapsed;
        _visibilityAnswer2 = Visibility.Collapsed;
        _input = string.Empty;
        
        // Commands
        SubmitCommand = new RelayCommand(_ => Submit(), _ => CanSubmit());
    }
    
    private void Submit()
    {
        LaunchLoading(async () =>
        {
            try
            {
                (Answer1, Answer2) = await SelectedDay.Value.GetResults(Input);
            }
            catch (Exception)
            {
                Answer1 = "Error";
                Answer2 = "";
            }
            finally
            {
                Input = "";
            }
        });
    }

    private bool CanSubmit()
    {
        return !string.IsNullOrWhiteSpace(Input);
    }

    private void LaunchLoading(Func<Task> function)
    {
        IsLoading = Visibility.Visible;
        Task.Run(async () =>
        {
            await function.Invoke();
            IsLoading = Visibility.Collapsed;
        });
    }
}