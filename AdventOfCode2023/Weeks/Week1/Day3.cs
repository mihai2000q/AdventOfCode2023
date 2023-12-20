namespace AdventOfCode2023.Weeks.Week1;

public class Day3 : AoC
{
    private record Point(int X, int Y);

    private static readonly List<Point> Directions = [
        new Point(-1, -1), // top-left
        new Point(-1, 0), // top
        new Point(-1, 1), // top-right
        new Point(0, 1), // right
        new Point(1, 1), // bottom-right
        new Point(1, 0), // bottom
        new Point(1, -1), // bottom-left
        new Point(0, -1), // left
    ];

    public override Task<string> Part1(string input)
    {
        var engineSchematic = ParseInput(input);

        var parts = new List<IEnumerable<char>>();

        var currentNumber = new List<(Point, char)>();

        for (var i = 0; i < engineSchematic.Length; i++)
        {
            var row = engineSchematic[i];
            for (var j = 0; j < row.Length; j++)
            {
                var currentChar = row[j];
                if (char.IsAsciiDigit(currentChar))
                {
                    currentNumber.Add((new Point(i, j), currentChar));
                }
                else
                {
                    ResetPart1(engineSchematic, ref currentNumber, parts);
                }
            }

            ResetPart1(engineSchematic, ref currentNumber, parts);
        }

        return Task.FromResult(
            parts
                .Select(x => string.Join("", x))
                .Select(long.Parse)
                .Sum()
                .ToString()
        );
    }
    
     private static void ResetPart1(
        IReadOnlyList<char[]> engineSchematic,
        ref List<(Point, char)> currentNumber,
        List<IEnumerable<char>> gearParts)
    {
        if (IsPart(engineSchematic, currentNumber))
        {
            gearParts.Add(currentNumber.Select(x => x.Item2));
        }

        currentNumber = [];
    }

    private static bool IsPart(
        IReadOnlyList<char[]> engineSchematic,
        IReadOnlyCollection<(Point, char)> currentNumber)
    {
        if (currentNumber.Count == 0) return false;

        var xCoordinate = currentNumber.First().Item1.X;
        var isFirstRow = xCoordinate == 0;
        var isLastRow = xCoordinate == engineSchematic.Count - 1;

        var leftYCoordinate = currentNumber.First().Item1.Y - 1;
        var rightYCoordinate = currentNumber.Last().Item1.Y + 1;

        if (leftYCoordinate >= 0)
        {
            // left
            if (IsSymbol(engineSchematic[xCoordinate][leftYCoordinate])) return true;
            // top-left
            if (!isFirstRow && IsSymbol(engineSchematic[xCoordinate - 1][leftYCoordinate])) return true;
            // bottom-left
            if (!isLastRow && IsSymbol(engineSchematic[xCoordinate + 1][leftYCoordinate])) return true;
        }

        if (rightYCoordinate < engineSchematic[0].Length)
        {
            // right
            if (IsSymbol(engineSchematic[xCoordinate][rightYCoordinate])) return true;
            // top-right
            if (!isFirstRow && IsSymbol(engineSchematic[xCoordinate - 1][rightYCoordinate])) return true;
            // bottom-right
            if (!isLastRow && IsSymbol(engineSchematic[xCoordinate + 1][rightYCoordinate])) return true;
        }

        foreach (var point in currentNumber.Select(x => x.Item1))
        {
            // above
            if (!isFirstRow && IsSymbol(engineSchematic[point.X - 1][point.Y])) return true;
            // below
            if (!isLastRow && IsSymbol(engineSchematic[point.X + 1][point.Y])) return true;
        }

        return false;
    }

    private static bool IsSymbol(char c)
    {
        return !char.IsAsciiDigit(c) && c != '.';
    }

    public override Task<string> Part2(string input)
    {
        var engineSchematic = ParseInput(input);

        var gears = new List<Point>();
        
        for (var i = 0; i < engineSchematic.Length; i++)
        {
            var row = engineSchematic[i];
            for (var j = 0; j < row.Length; j++)
            {
                if (IsGear(row[j]))
                {
                    gears.Add(new Point(i, j));
                }
            }
        }

        var gearRatios = gears.Sum(gear => GetGearRatio(engineSchematic, gear));

        return Task.FromResult(gearRatios.ToString());
    }

    private static bool IsGear(char c)
    {
        return c == '*';
    }

    private static long GetGearRatio(IReadOnlyList<char[]> engineSchematic, Point gear)
    {
        var numbers = new List<long>();

        var visited = new List<Point>();
        
        foreach (var direction in Directions)
        {
            var x = gear.X + direction.X;
            var y = gear.Y + direction.Y;
            if (visited.FirstOrDefault(p => p.X == x && p.Y == y) is not null) continue;
            visited.Add(new Point(x, y));
            if (x < 0 || x >= engineSchematic.Count || y < 0 || y >= engineSchematic[0].Length) continue;
            
            if (char.IsAsciiDigit(engineSchematic[x][y]))
            {
                numbers.Add(GetNumberFromSchema(engineSchematic, x, y, visited));
            }
        }
        
        if (numbers.Count == 2)
        {
            return numbers[0] * numbers[1];
        }
        
        return 0;
    }

    private static long GetNumberFromSchema(IReadOnlyList<char[]> engineSchematic, int x, int y, ICollection<Point> visited)
    {
        while (true)
        {
            if (!char.IsAsciiDigit(engineSchematic[x][y])) break;
            if (y-- == 0) break;
        }

        var digits = new List<char>();
        for (var i = y + 1; i < engineSchematic[0].Length; i++)
        {
            visited.Add(new Point(x, i));
            if (!char.IsAsciiDigit(engineSchematic[x][i])) break;
            
            digits.Add(engineSchematic[x][i]);
        }

        return long.Parse(string.Join("", digits));
    }

    private static char[][] ParseInput(string input)
    {
        return input
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.ToArray())
            .ToArray();
    }
}