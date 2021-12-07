var input = File.ReadAllText("input.txt").Split(',').Select(x => int.Parse(x));

Console.WriteLine($"Part 1: {cost1(input)}");
Console.WriteLine($"Part 2: {cost2(input)}");

int median(IEnumerable<int> values)
{
    var arry = values.ToArray();
    return arry[arry.Length / 2];
}

int cost1(IEnumerable<int> values)
{
    int position = median(values);
    return Math.Min(values.Sum(x => Math.Abs(x - position)), values.Sum(x => Math.Abs(x - position + 1)));
}

int cost2(IEnumerable<int> values)
{
    var ceil = (int)values.Average();
    var floor = ceil + 1;
    return Math.Min(values.Sum(x => (Math.Abs(x - ceil) * (Math.Abs(x - ceil) +1) /2)), values.Sum(x => Math.Abs(x - floor) * (Math.Abs(x - floor) + 1) / 2));
}