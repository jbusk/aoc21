
using (var sr = new StreamReader("input.txt"))
{
    int hpos = 0;
    int depth = 0;
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!;
        var direction = line.Substring(0, line.IndexOf(' '));
        var value = int.Parse(line.Substring(line.IndexOf(' ')));
        switch (direction)
        {
            case "forward":
                hpos += value;
                break;
            case "down":
                depth += value;
                break;
            case "up":
                depth -= value;
                break;
            default:
                break;
        }

    }
    Console.WriteLine($"hpos {hpos} * depth {depth} = {hpos * depth}");
}