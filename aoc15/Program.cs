Dictionary<(int, int), int> grid = new();
int max_y = 0;
int max_x = 0;
using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!;
        max_x = line.Length - 1;
        for (int x = 0; x <= max_x; x++)
        {
            grid.Add((x, max_y), (int.Parse(line[x].ToString())));
        }
        max_y++;
    }
    max_y--;
}

Console.WriteLine("Part 1: " + dijkstra(grid));

Console.WriteLine("Part 2: " + dijkstra(multiply_by_5(grid)));

Dictionary<(int, int), int> multiply_by_5(Dictionary<(int, int), int> grid)
{
    Dictionary<(int, int), int> newgrid = new();
    foreach (var point in grid)
    {
        var key = point.Key;
        var value = point.Value;
        // original
        newgrid.Add(key, value);
        // 1 away
        newgrid.Add((key.Item1, key.Item2 + 100), risk(value, 1));
        newgrid.Add((key.Item1+100, key.Item2), risk(value, 1));
        // 2 away
        newgrid.Add((key.Item1 + 200, key.Item2), risk(value, 2));
        newgrid.Add((key.Item1 + 100, key.Item2+ 100), risk(value, 2));
        newgrid.Add((key.Item1, key.Item2+200), risk(value, 2));
        // 3 away
        newgrid.Add((key.Item1 + 300, key.Item2), risk(value, 3));
        newgrid.Add((key.Item1 + 200, key.Item2 + 100), risk(value, 3));
        newgrid.Add((key.Item1 + 100, key.Item2 + 200), risk(value, 3));
        newgrid.Add((key.Item1, key.Item2 + 300), risk(value, 3));
        // 4 away
        newgrid.Add((key.Item1 + 400, key.Item2), risk(value, 4));
        newgrid.Add((key.Item1 + 300, key.Item2 + 100), risk(value, 4));
        newgrid.Add((key.Item1 + 200, key.Item2 + 200), risk(value, 4));
        newgrid.Add((key.Item1 + 100, key.Item2 + 300), risk(value, 4));
        newgrid.Add((key.Item1, key.Item2 + 400), risk(value, 4));
        // 5 away
        newgrid.Add((key.Item1 + 100, key.Item2 + 400), risk(value, 5));
        newgrid.Add((key.Item1 + 200, key.Item2 + 300), risk(value, 5));
        newgrid.Add((key.Item1 + 300, key.Item2 + 200), risk(value, 5));
        newgrid.Add((key.Item1 + 400, key.Item2 + 100), risk(value, 5));
        // 6 away
        newgrid.Add((key.Item1 + 400, key.Item2 + 200), risk(value, 6));
        newgrid.Add((key.Item1 + 300, key.Item2 + 300), risk(value, 6));
        newgrid.Add((key.Item1 + 200, key.Item2 + 400), risk(value, 6));
        // 7 away
        newgrid.Add((key.Item1 + 400, key.Item2 + 300), risk(value, 7));
        newgrid.Add((key.Item1 + 300, key.Item2 + 400), risk(value, 7));
        // 8 away
        newgrid.Add((key.Item1 + 400, key.Item2 + 400), risk(value, 8));
    }
    max_x = 499;
    max_y = 499;

    return newgrid;
}

int risk(int value, int distance)
{
    return (value + distance - 1) % 9 + 1;
}

int dijkstra(Dictionary<(int, int), int> map)
{
    var topLeft = (0, 0);
    var bottomRight = (max_x, max_y);
    var q = new PriorityQueue<(int, int), int>();
    var totalRiskMap = new Dictionary<(int, int), int>();

    totalRiskMap[topLeft] = 0;
    q.Enqueue(topLeft, 0);

    while (q.Count > 0)
    {
        var p = q.Dequeue();

        foreach (var n in neighbours(p))
        {
            if (map.ContainsKey(n) && !totalRiskMap.ContainsKey(n))
            {
                var totalRisk = totalRiskMap[p] + map[n];
                totalRiskMap[n] = totalRisk;
                if (n == bottomRight)
                {
                    break;
                }
                var h = 0;
                q.Enqueue(n, totalRisk + h);
            }
        }
    }

    return totalRiskMap[bottomRight];
}

IEnumerable<(int, int)> neighbours((int, int) point)
{
    (int x, int y) = (point.Item1, point.Item2);
    return new[] {
           (x, y + 1),
           (x, y - 1),
           (x + 1, y),
           (x - 1, y),
    };
}