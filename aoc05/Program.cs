var vents = new int[1000, 1000];
using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!.Split(" -> ");
        (string[] point1, string[] point2) = (line[0].Split(','), line[1].Split(',').ToArray());
        (int x1, int x2, int y1, int y2) = (int.Parse(point1[0]), int.Parse(point2[0]), int.Parse(point1[1]), int.Parse(point2[1]));
        int xstep = x1 == x2 ? 0 : (x1 < x2 ? 1 : -1);
        int ystep = y1 == y2 ? 0 : (y1 < y2 ? 1 : -1);
        int stopx = x2 + (xstep == 0 ? 1 : xstep);
        int stopy = y2 + (ystep == 0 ? 1 : ystep);
        for (int x = x1, y = y1; x != stopx && y != stopy; x += xstep, y += ystep)
        {
            vents[x, y]++;
        }
    }
}
Console.WriteLine(vents.Cast<int>().Count(x => x > 1));