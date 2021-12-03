using aoc03;


List<BinaryPair> pairs = new();
using (var sr = new StreamReader("input.txt"))
{
    var firstline = sr.ReadLine()!;
    for (int i = 0; i < firstline.Length; i++)
    {
        pairs.Add(new BinaryPair(int.Parse(firstline.Substring(i, 1))));
    }

    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!;
        for (int i = 0; i < line.Length; i++)
        {
            pairs[i].Add(int.Parse((line.Substring(i, 1))));
        }
    }
}

string maxresult = "";
string minresult = "";
foreach (var item in pairs)
{
    maxresult += item.Max();
    minresult += item.Min();
}
int max = Convert.ToInt32(maxresult, 2);
int min = Convert.ToInt32(minresult, 2);
Console.WriteLine(max*min);

