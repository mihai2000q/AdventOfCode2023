using System.Collections.ObjectModel;
using AdventOfCode2023.UI.Model;
using AdventOfCode2023.Weeks.Week1;

namespace AdventOfCode2023.UI.Helper;

public static class Constants
{
    public static readonly ObservableCollection<Day> Days = [
        new Day
        {
            DisplayText = "Day 1: Trebuchet?!",
            Value = new Day1()
        },
        new Day
        {
            DisplayText = "Day 2: Cube Conundrum",
            Value = new Day2()
        }
    ];
}