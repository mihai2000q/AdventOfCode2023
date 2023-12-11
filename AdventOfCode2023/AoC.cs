namespace AdventOfCode2023;

public abstract class AoC
{
    public async Task<(string, string)> GetResults(string input)
    {
        return (await Part1(input), await Part2(input));
    }
    
    public abstract Task<string> Part1(string input);
    
    public abstract Task<string> Part2(string input);
}