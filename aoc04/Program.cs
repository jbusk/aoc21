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
BingoBoard? last_winning = null;
int last_winning_sum = 0;
int last_winning_call = 0;
foreach (var callstr in calls.Split(','))
{
    int call = int.Parse(callstr);
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
            last_winning = board;
            last_winning_call = call;
            last_winning_sum = sum;
        }
    }
}
Console.WriteLine($"Part 2: {last_winning_sum} * {last_winning_call} = {last_winning_sum * last_winning_call}");
Console.WriteLine(last_winning);