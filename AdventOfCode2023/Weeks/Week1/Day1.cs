namespace AdventOfCode2023.Weeks.Week1;

public class Day1 : AoC
{
    // The point is: when replacing a word, we should not lose the potential other combinations
    // for example, if the words is: "threeight", if we replace three with 3, then eight cannot become 8
    private static readonly Dictionary<string, string> LettersToDigits = new()
    {
        { "one", "one1one" },
        { "two", "two2two" },
        { "three", "three3three" },
        { "four", "four4four" },
        { "five", "five5five" },
        { "six", "six6six" },
        { "seven", "seven7seven" },
        { "eight", "eight8eight" },
        { "nine", "nine9nine" }
    };

    private static readonly List<string> Digits =
        ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public override Task<string> Part1(string input)
    {
        return Task.FromResult(GetSumOfCalibrationValues(input));
    }

    public override Task<string> Part2(string input)
    {
        return Task.FromResult(
            GetSumOfCalibrationValues(
                ReplaceSpelledDigitsWithDigits(input)
            )
        );
    }

    private static string GetSumOfCalibrationValues(string input)
    {
        return GetSumOfCalibrationValues(input.Split("\r\n"));
    }

    private static string GetSumOfCalibrationValues(IEnumerable<string> input)
    {
        return input
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.FirstOrDefault(char.IsDigit) + line.LastOrDefault(char.IsDigit).ToString())
            .Sum(x => int.TryParse(x, out var result) ? result : 0)
            .ToString();
    }

    // Another solution would be to not replace the spelled digits
    private static List<string> ReplaceSpelledDigitsWithDigits(string input)
    {
        return input
            .Split("\r\n")
            .Select(line =>
                Digits.Aggregate(line, (current, digit) =>
                    current.Replace(digit, LettersToDigits[digit])
                )
            ).ToList();
    }
}