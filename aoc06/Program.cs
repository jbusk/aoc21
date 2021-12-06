using aoc06;

List<Fish> fishes = new();
var input = File.ReadAllText("input.txt").Split(',').Select(x => int.Parse(x));
foreach (var item in input)
{
    var fisk = fishes.Find(x => x.Counter == item);
    if (fisk == null)
        fishes.Add(new Fish(item));
    else
        fisk.AddAmount(1);
}

for (int i = 0; i < 256; i++)
{
    long fishtoadd = 0;
    foreach (var fish in fishes)
    {
        fishtoadd += fish.Day();
    }
    fishes.Add(new Fish(8, fishtoadd));
    List<Fish> school = new();
    for (int j = 0; j <= 8; j++)
    {
        long num = fishes.FindAll(x=> x.Counter == j).Sum(x => x.Amount);
        school.Add(new Fish(j, num));
    }
    fishes = school;

    if (i == 79)
    {
        Console.WriteLine("Part 1: " + fishes.Sum(x => x.Amount));
    }
}

Console.WriteLine("Part 2: " + fishes.Sum(x => x.Amount));