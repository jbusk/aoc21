
using (var sr = new StreamReader("input.txt"))
{
    int aim = 0;
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
                depth += aim * value;
                break;
            case "down":
                aim += value;
                break;
            case "up":
                aim -= value;
                break;
            default:
                break;
        }

    }
    Console.WriteLine($"hpos {hpos} * depth {depth} = {hpos * depth}");
}