using aoc04;

List<BingoBoard> boards = new();
string calls;
using (var sr = new StreamReader("input.txt"))
{
    calls = sr.ReadLine()!;
    while (!sr.EndOfStream)
    {
        sr.ReadLine();
        var line1 = sr.ReadLine()! + " ";
        var line2 = sr.ReadLine()! + " ";
        var line3 = sr.ReadLine()! + " ";
        var line4 = sr.ReadLine()! + " ";
        var line5 = sr.ReadLine()!;
        boards.Add(new BingoBoard($"{line1 + line2 + line3 + line4 + line5}".Trim()));
    }
}

bool first_has_won = false;

foreach (var call in calls.Split(',').Select(f => int.Parse(f)))
{
    foreach (var board in boards)
    {
        if (!board.Won && board.Call(call))
        {
            int sum = board.Sum;
            if (!first_has_won)
            {
                Console.WriteLine($"Part 1: {sum} * {call} = {sum * call}");
                Console.WriteLine(board);
                first_has_won = true;
            }
            if (boards.Count(b => !b.Won) == 0)
            {
                Console.WriteLine($"Part 1: {sum} * {call} = {sum * call}");
                Console.WriteLine(board);
            }
        }
    }
}