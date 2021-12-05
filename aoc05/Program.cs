int[][] vents = new int[1000][];
for (int i = 0; i < vents.Length; i++)
{
    vents[i] = new int[1000];
}

using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        // 0,9 -> 5,9
        var line = sr.ReadLine()!.Split(" -> ");
        //Console.WriteLine(line[0] + " -> " + line[1]);
        (var beg, var end) = (line[0].Split(','), line[1].Split(',').ToArray());
        // ignoring diagonals for now
        // vertical
        if (beg[0] == end[0])
        {
            var horiz = int.Parse(beg[0]);
            var start = min(int.Parse(beg[1]), int.Parse(end[1]));
            var stop = max(int.Parse(beg[1]), int.Parse(end[1]));
            for (int i = start; i <= stop; i++)
            {
                //Console.WriteLine($"({i},{horiz})");
                vents[i][horiz]++;
            }
        }
        // horizontal
        if(beg[1] == end[1])
        {
            var vert = int.Parse(beg[1]);
            var start = min(int.Parse(beg[0]), int.Parse(end[0]));
            var stop = max(int.Parse(beg[0]), int.Parse(end[0]));
            for (int i = start; i <= stop; i++)
            {
                //Console.WriteLine($"({vert},{i})");
                vents[vert][i]++;
            }
        }
        
    }
}
var sum = 0;
for (int i = 0; i < vents.Length; i++)
{
    for (int j = 0; j < vents[i].Length; j++)
    {
        if (vents[i][j] > 1)
            sum++;
    }
}


Console.WriteLine(sum);

static int min(int x, int y)
{
    if (x > y)
        return y;
    return x;
}

static int max(int x, int y)
{
    if (y > x)
        return y;
    return x;
}