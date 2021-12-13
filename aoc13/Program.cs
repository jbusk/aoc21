var dots = new HashSet<(int, int)>();
int pt1 = 0;
bool pt1get = true;
using (var sr = new StreamReader("input.txt"))
{
    // add dots to grid
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!;
        // fold instructions begin after an empty line
        if (string.IsNullOrWhiteSpace(line))
            break;
        var split = line.Split(",").Select(int.Parse);
        dots.Add((split.First(), split.Last()));

    }

    // fold
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!;
        var instruction = line.Substring(line.IndexOf('=') - 1).Split('=');
        switch (instruction.First())
        {
            case "x":
                dots = fold_x(int.Parse(instruction.Last()));
                break;
            case "y":
                dots = fold_y(int.Parse(instruction.Last()));
                break;
            default:
                break;
        }
        if (pt1get)
        {
            pt1 = dots.Count;
            pt1get = false;
        }
    }

    HashSet<(int, int)> fold_x(int value)
    {
        Console.WriteLine("Folding on x at " + value);
        HashSet<(int, int)> fold = new HashSet<(int, int)>();
        foreach (var dot in dots)
        {
            if (dot.Item1 > value)
                fold.Add((Math.Abs(dot.Item1 - (2 * value) ), dot.Item2));
            else
                fold.Add(dot);
        }
        return fold;
    }
    HashSet<(int, int)> fold_y(int value)
    {
        HashSet<(int, int)> fold = new HashSet<(int, int)>();
        foreach (var dot in dots)
        {
            if (dot.Item2 > value)
                fold.Add((dot.Item1, Math.Abs(dot.Item2 - (2 * value) )));
            else
                fold.Add(dot);
        }
        return fold;
    }

    
}

Console.WriteLine("Part 1 " + pt1);
Console.WriteLine("Part 2 :");
visualise_grid(dots);

void visualise_grid(HashSet<(int, int)> grid)
{
    Console.WriteLine();
    for (int y = 0; y < grid.Select(a => a.Item2).Max() +1 ; y++)
    {
        for (int x = 0; x < grid.Select(a => a.Item1).Max() +1; x++)
        {
            if (grid.Contains((x, y)))
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}