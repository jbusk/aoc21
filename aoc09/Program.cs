using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = File.ReadAllLines("input.txt");
var grid = input.Select(l => l.ToArray()).ToArray();

IEnumerable<(int y, int x)> adjacent(int y, int x)
{
    if (x > 0) yield return (y, x - 1);
    if (x < grid[0].Length - 1) yield return (y, x + 1);
    if (y > 0) yield return (y - 1, x);
    if (y < grid.Length - 1) yield return (y + 1, x);
}
var lows = new List<(int y, int x)>();
for (int y = 0; y < grid.Length; ++y)
{
    for (int x = 0; x < grid[0].Length; ++x)
    {
        if (adjacent(y, x).All(a => grid[a.y][a.x] > grid[y][x])) lows.Add((y, x));
    }
}

var part1 = lows.Sum(a => int.Parse($"{grid[a.y][a.x]}")) + lows.Count;
Console.WriteLine($"Part 1: {part1}");

var visited = new HashSet<(int y, int x)>();
IEnumerable<(int y, int x)> basin((int y, int x) low)
{
    if (!visited.Contains(low) && grid[low.y][low.x] != '9')
    {
        visited.Add(low);
        yield return low;

        foreach (var a in adjacent(low.y, low.x))
            foreach (var c in basin(a))
                yield return c;
    }
}
var basins = lows.Select(l => basin(l).ToArray()).OrderByDescending(b => b.Length).ToArray();

var part2 = basins.Take(3).Aggregate(1L, (s, b) => s * b.Count());
Console.WriteLine($"Part 2: {part2}");