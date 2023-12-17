namespace AdventOfCode2023.Weeks.Week1;

public class Day2 : AoC
{
    private static readonly IReadOnlyDictionary<string, int> ColorsToMax = new Dictionary<string, int>()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };

    private static readonly IReadOnlyDictionary<string, int> InitialCubeColors = new Dictionary<string, int>()
    {
        { "red", 0 },
        { "green", 0 },
        { "blue", 0 }
    };

    public override Task<string> Part1(string input)
    {
        return Task.FromResult(
            input
                .Split("\r\n")
                .Select(game => game.Split(": "))
                .Select(game => new { ID = GetGameId(game.First()), CubeConfigurations = game.Last() })
                .Where(game =>
                    game.CubeConfigurations
                        .Split("; ")
                        .Select(configuration => configuration.Split(", "))
                        .All(IsConfigurationPossible)
                )
                .Select(game => game.ID)
                .Sum()
                .ToString()
        );
    }

    private static int GetGameId(string game) => int.Parse(game.Split(" ").Last());

    private static bool IsConfigurationPossible(IEnumerable<string> configuration)
    {
        foreach (var cube in configuration)
        {
            var cubeNo = cube.Split(" ").First();
            var cubeColor = cube.Split(" ").Last();

            if (int.Parse(cubeNo) > ColorsToMax[cubeColor]) return false;
        }

        return true;
    }

    public override Task<string> Part2(string input)
    {
        return Task.FromResult(
            input
                .Split("\r\n")
                .Select(game => game.Split(": "))
                .Select(game => game.Last())
                .Select(configurations =>
                    configurations
                        .Split("; ")
                        .Select(configuration => configuration.Split(", "))
                )
                .Select(GetPowerOfGameSet)
                .Sum()
                .ToString()
        );
    }

    private static int GetPowerOfGameSet(IEnumerable<string[]> configurations)
    {
        var cubeColorsAndMaxAmount = InitialCubeColors.ToDictionary();

        configurations
            .ToList()
            .ForEach(configuration =>
                configuration
                    .Select(cube => cube.Split(" "))
                    .Select(cubeValues => new { Amount = int.Parse(cubeValues.First()), Color = cubeValues.Last() })
                    .ToList()
                    .ForEach(cube =>
                        cubeColorsAndMaxAmount[cube.Color] = cube.Amount > cubeColorsAndMaxAmount[cube.Color]
                            ? cube.Amount
                            : cubeColorsAndMaxAmount[cube.Color]
                    )
            );

        return cubeColorsAndMaxAmount.Values.Aggregate((x, y) => x * y);
    }
}