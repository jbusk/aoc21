var file = File.ReadAllText("input.txt").Split('\n').Select(x => x.Split(" | "));
var pt1count = 0;
var pt2sum = 0;
foreach (var line in file)
{
    var input = line[0].Trim().Split(" ").Select(sortString);
    var output = line[1].Trim().Split(" ").Select(sortString);

    var seg = new string[10];
    seg[1] = input.Where(x => x.Length == 2).First();
    seg[4] = input.Where(x => x.Length == 4).First();
    seg[0] = input.Where(x => x.Length == 6 && common_with_one(x, 2) && common_with_four(x, 3)).First();
    seg[2] = input.Where(x => x.Length == 5 && common_with_one(x, 1) && common_with_four(x, 2)).First();
    seg[3] = input.Where(x => x.Length == 5 && common_with_one(x, 2) && common_with_four(x, 3)).First();
    seg[5] = input.Where(x => x.Length == 5 && common_with_one(x, 1) && common_with_four(x, 3)).First();
    seg[6] = input.Where(x => x.Length == 6 && common_with_one(x, 1) && common_with_four(x, 3)).First();
    seg[7] = input.Where(x => x.Length == 3).First();
    seg[8] = input.Where(x => x.Length == 7).First();
    seg[9] = input.Where(x => x.Length == 6 && common_with_one(x, 2) && common_with_four(x, 4)).First();

    var segment = seg.ToList();
    string outval = "";
    foreach (var item in output)
    {
        var val = segment.IndexOf(item);
        outval += val;
        if (val == 1 || val == 4 || val == 7 || val == 8)
            pt1count++;
    }
    pt2sum += int.Parse(outval);

    bool common_with_one(string param, int num)
    {
        return num == commonWith(param, seg![1]);
    }
    bool common_with_four(string param, int num)
    {
        return (num == commonWith(param, seg![4]));
    }
}
Console.WriteLine("Part 1: " + pt1count);
Console.WriteLine("Part 2: " + pt2sum);

string sortString(string param)
{
    var arry = param.ToCharArray();
    Array.Sort(arry);
    return string.Join("", arry);
}
int commonWith(string param, string cmp)
{
    var it = param.ToCharArray();
    var ot = it.Except(cmp.ToCharArray());
    return it.Length - ot.Count();
}
