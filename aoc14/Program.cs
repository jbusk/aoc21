string start;
Dictionary<string, string> links = new Dictionary<string, string>();
using (var sr = new StreamReader("input.txt"))
{
    start = sr.ReadLine()!;
    sr.ReadLine();


    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!.Split(" -> ");
        links[line[0]] = line[1];
    }
}

var pairs = Enumerable.Range(0, start.Length - 1).Select(x => start[x..(x + 2)]);
var dict = pairs.GroupBy(x => x).ToDictionary(y => y.Key, y => (long)y.Count());

var count = start.GroupBy(x => x).ToDictionary(y => y.Key, y => (long)y.Count());

for (int i = 0; i < 40; i++)
{
    var newPairs = new Dictionary<string, long>();

    foreach (var item in dict)
    {
        var insert = links[item.Key];
        var newPair1 = item.Key.ToString()[0] + insert;
        var newPair2 = insert + item.Key.ToString()[1];
        if (!count.ContainsKey(char.Parse(insert)))
        {
            count.Add(char.Parse(insert), 1);
        }
        else
        {
            count[char.Parse(insert)] += item.Value;
        }
        if (newPairs.ContainsKey(newPair1))
        {
            newPairs[newPair1] += item.Value;
        }
        else
        {
            newPairs.Add(newPair1, item.Value);
        }
        if (newPairs.ContainsKey(newPair2))
        {
            newPairs[newPair2] += item.Value;
        }
        else
        {
            newPairs.Add(newPair2, item.Value);
        }

    }
    dict = new Dictionary<string, long>(newPairs);
}

var min = count.Aggregate((l, r) => l.Value < r.Value ? l : r).Value;
var max = count.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;

Console.WriteLine(max - min);