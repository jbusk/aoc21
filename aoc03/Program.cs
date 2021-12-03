using aoc03;

int valuelength = 0;
List<string> values = new();
using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
        values.Add(sr.ReadLine()!);
}


var pairs = GetBinaryPairs(values);
(var max, var min, var maxresult, var minresult) = GetMaxAndMin(pairs);
Console.WriteLine("Part 1: " + max * min);


var oxy = new List<string>(values);
var oxypairs = new List<BinaryPair>(pairs);
var co2 = new List<string>(values);
var co2pairs = new List<BinaryPair>(pairs);
(var oxyresult, var co2result) = getOxyAndCO(oxypairs, co2pairs);
for (int i = 0; i < valuelength; i++)
{
    if (oxy.Count != 1)
        oxy.RemoveAll(x => x[i] != oxyresult[i]);
    if (co2.Count != 1)
        co2.RemoveAll(x => x[i] != co2result[i]);
    oxypairs = GetBinaryPairs(oxy);
    co2pairs = GetBinaryPairs(co2);
    (oxyresult, co2result) = getOxyAndCO(oxypairs, co2pairs);
}

Console.WriteLine("Part 2: " + toBase10(oxy.First()) * toBase10(co2.First()));

List<BinaryPair> GetBinaryPairs(List<string> values)
{
    bool first = true;
    List<BinaryPair> pairs = new();
    foreach (var item in values)
    {
        if (first)
        {
            valuelength = item.Length;
            for (int i = 0; i < valuelength; i++)
            {
                pairs.Add(new BinaryPair());
            }
            first = false;
        }
        for (int i = 0; i < valuelength; i++)
        {
            pairs[i].Add(int.Parse((item.Substring(i, 1))));
        }
    }
    return pairs;
}

(int, int, string, string) GetMaxAndMin(List<BinaryPair> pairs)
{
    string maxresult = "";
    string minresult = "";
    foreach (var item in pairs)
    {
        maxresult += item.Max();
        minresult += item.Min();
    }
    int max = toBase10(maxresult);
    int min = toBase10(minresult);
    return (max, min, maxresult, minresult);
}

(string, string) getOxyAndCO(List<BinaryPair> oxypairs, List<BinaryPair> co2pairs)
{
    string oxyresult = "";
    string co2result = "";
    foreach (var item in oxypairs)
    {
        oxyresult += item.Oxy();
    }
    foreach (var item in co2pairs)
    {
        co2result += item.Co2();
    }
    return (oxyresult, co2result);
}

int toBase10(string val)
{
    return Convert.ToInt32(val, 2);
}