using AdventOfCode2023.Weeks.Week1;

namespace AdventOfCode2023.Tests.Weeks.Week1;

public class Day3Test
{
    private const string TestInput = """
                                     467..114..
                                     ...*......
                                     ..35..633.
                                     ......#...
                                     617*......
                                     .....+.58.
                                     ..592.....
                                     ......755.
                                     ...$.*....
                                     .664.598..
                                     """;
    
    private const string TestInput2 = """
                                      12.......*..
                                      +.........34
                                      .......-12..
                                      ..78........
                                      ..*....60...
                                      78..........
                                      .......23...
                                      ....90*12...
                                      ............
                                      2.2......12.
                                      .*.........*
                                      1.1.......56
                                      """;

    private const string TestInput3 = """
                                      12.......*..
                                      +.........34
                                      .......-12..
                                      ..78........
                                      ..*....60...
                                      78.........9
                                      .5.....23..$
                                      8...90*12...
                                      ............
                                      2.2......12.
                                      .*.........*
                                      1.1..503+.56
                                      """;

    private readonly Day3 _uut = new();

    [Fact]
    public async Task Day3_Test_Part1()
    {
        var res = await _uut.Part1(TestInput);
            
        Assert.Equal(4361, int.Parse(res));
    }
    
    [Fact]
    public async Task Day3_Test_Part2()
    {
        var res = await _uut.Part2(TestInput);
            
        Assert.Equal(467835, int.Parse(res));
    }
    
    [Fact]
    public async Task Day3_Test_Part2_TestCase2()
    {
        var res = await _uut.Part2(TestInput2);
            
        Assert.Equal(6756, int.Parse(res));
    }
    
    [Fact]
    public async Task Day3_Test_Part2_TestCase3()
    {
        var res = await _uut.Part2(TestInput3);
            
        Assert.Equal(6756, int.Parse(res));
    }
}