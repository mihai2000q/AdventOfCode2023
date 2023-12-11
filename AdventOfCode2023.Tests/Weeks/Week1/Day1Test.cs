using AdventOfCode2023.Weeks.Week1;

namespace AdventOfCode2023.Tests.Weeks.Week1;

public class Day1Test
{
    private const string TestInput = """
                                     1abc2
                                     pqr3stu8vwx
                                     a1b2c3d4e5f
                                     treb7uchet
                                     """;
    
    private const string TestInput2 = """
                                     two1nine
                                     eightwothree
                                     abcone2threexyz
                                     xtwone3four
                                     4nineeightseven2
                                     zoneight234
                                     7pqrstsixteen
                                     """;

    private readonly Day1 _uut = new();

    [Fact]
    public async Task Day1_Test_Part1()
    {
        var res = await _uut.Part1(TestInput);
            
        Assert.Equal(142, int.Parse(res));
    }
    
    [Fact]
    public async Task Day1_Test_Part2()
    {
        var res = await _uut.Part2(TestInput2);
            
        Assert.Equal(281, int.Parse(res));
    }
}