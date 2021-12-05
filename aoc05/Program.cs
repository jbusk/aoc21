var vents = new int[1000,1000];
using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!.Split(" -> ");
        (var beg, var end) = (line[0].Split(','), line[1].Split(',').ToArray());
        (var x1, var x2, var y1, var y2) = (int.Parse(beg[0]), int.Parse(end[0]), int.Parse(beg[1]), int.Parse(end[1]));
        
        if (x1 == x2 || y1 == y2)
        {
            (int xdiff, int ydiff) = (x1 - x2, y1 - y2);
            for (int x = 0; x <= Math.Abs(xdiff); x++)
            {
                for (int y = 0; y <= Math.Abs(ydiff); y++)
                {
                    (var xc, var yc) = (x1 + ((xdiff < 0) ? x : x * -1), y1 + ((ydiff < 0) ? y : y * -1));
                    vents[xc, yc]++; 
                }
            }
        }
        else
        {
            (var diff, var xdir, var ydir) = (Math.Abs(x1 - x2), x1 - x2, y1 - y2);
            for (int xy = 0; xy <= diff; xy++)
            {
                (var xc, var yc) = (x1 + ((xdir < 0) ? xy : xy * -1), y1 + ((ydir < 0) ? xy : xy * -1));
                vents[xc, yc]++;
            }
        }
    }
}
Console.WriteLine(vents.Cast<int>().Count(x => x > 1));