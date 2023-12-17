using AdventOfCode2023.Weeks.Week1;

namespace AdventOfCode2023.Tests.Weeks.Week1;

public class Day2Test
{
    private const string TestInput = """
                                     Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                                     Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                                     Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                                     Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                                     Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                                     """;

    private readonly Day2 _uut = new();

    [Fact]
    public async Task Day2_Test_Part1()
    {
        var res = await _uut.Part1(TestInput);
            
        Assert.Equal(8, int.Parse(res));
    }
    
    [Fact]
    public async Task Day2_Test_Part2()
    {
        var res = await _uut.Part2(TestInput);
            
        Assert.Equal(2286, int.Parse(res));
    }
}