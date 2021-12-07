using aoc07;

var input = File.ReadAllText("input.txt").Split(',').Select(x => int.Parse(x));

List<Crab> crabs = new();
foreach (var pos in input)
{
    var crab = crabs.Find(x => x.Position == pos);
    if (crab == null)
        crabs.Add(new Crab(pos));
    else
        crab.Amount++;
}

int lowest = crabs.MinBy(x => x.Position)!.Position;
int highest = crabs.MaxBy(x => x.Position)!.Position;
int pt1cheapest = int.MaxValue;
int pt2cheapest = int.MaxValue;
for (int i = lowest; i < highest; i++)
{
    int pt1cost = crabs.Sum(x => x.Pt1Align(i));
    int pt2cost = crabs.Sum(x => x.Pt2Align(i));
    if (pt1cost < pt1cheapest)
        pt1cheapest = pt1cost;
    if (pt2cost < pt2cheapest)
        pt2cheapest = pt2cost;
}

Console.WriteLine($"Part 1: {pt1cheapest}");
Console.WriteLine($"Part 2: {pt2cheapest}");