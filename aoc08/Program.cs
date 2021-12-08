var file = File.ReadAllText("input.txt").Split('\n').Select(x => x.Split(" | "));
var sum = 0;
foreach (var line in file)
{
    var input = line[0].Trim().Split(" ").Select(x => x.ToCharArray());
    var output = line[1].Trim().Split(" ").Select(x => x.ToCharArray());
    //1, 4, 7, 8 can be figured out by length
    var digit1 = input.Where(x => x.Length == 2).First(); 
    var digit4 = input.Where(x => x.Length == 4).First();
    var digit7 = input.Where(x => x.Length == 3).First();
    var digit8 = input.Where(x => x.Length == 7).First();
    // right now c could be f and vice versa
    var seg_c_or_f = digit1[0];
    var seg_f_or_c = digit1[1];
    // seg_a is in 7 but not 1
    var seg_a = digit7.Except(digit1).First();
    // 3 is the only with length 5 which contains c and f
    var digit3 = input.Where(x => x.Length == 5 && x.Contains(seg_c_or_f) && x.Contains(seg_f_or_c)).First();
    // seg_g is in 3, but not 4 + seg_a
    var seg_g = digit3.Except(digit4).Except(new char[] { seg_a }).First();
    // seg_b is in 4 but not 3
    var seg_b = digit4.Except(digit3).First();
    // seg_e is in 8, but not 4, and it's not a nor g
    var seg_e = digit8.Except(digit4).Except(new char[] { seg_a, seg_g }).First();
    // we have all segments for 0
    var digit0 = input.Where(x => x.Length == 6 && x.Contains(seg_a) &&
    x.Contains(seg_b) && x.Contains(seg_c_or_f) && x.Contains(seg_e) &&
    x.Contains(seg_f_or_c) && x.Contains(seg_g)).First();
    // seg_d is in 8 but not 0
    var seg_d = digit8.Except(digit0).First();
    var sixes = input.Where(x => x.Length == 6).ToList();
    List<char> array6_cand = new() { ' ' };
    foreach (var item in sixes)
    {
        // 6 is the only of length 6 that contains seg d and e
        if (item.Contains(seg_d) && item.Contains(seg_e))
            array6_cand = new List<char>(item);
    }
    // seg_c is in 1 but not 6
    var seg_c = digit1.Except(array6_cand).First();
    // seg_f is in 1 but is not seg_c
    var seg_f = digit1.Except(new char[] { seg_c }).First();
    // since we have all segments now we can construct the remaining digits
    var digit2 = input.Where(x => x.Length == 5 && x.Contains(seg_a) && x.Contains(seg_c) && x.Contains(seg_d) && x.Contains(seg_e) && x.Contains(seg_g)).First();
    var digit5 = input.Where(x => x.Length == 5 && x.Contains(seg_a) && x.Contains(seg_b) && x.Contains(seg_d) && x.Contains(seg_f) && x.Contains(seg_g)).First();
    var digit9 = input.Where(x => x.Length == 6 && x.Contains(seg_a) && x.Contains(seg_b) && x.Contains(seg_c) && x.Contains(seg_d) && x.Contains(seg_f)
    && x.Contains(seg_g)).First();
    var digit6 = input.Where(x => x.Length == 6 && x.Contains(seg_a) && x.Contains(seg_b) && x.Contains(seg_d) && x.Contains(seg_e) && x.Contains(seg_f) && x.Contains(seg_g)).First();
    Array.Sort(digit0);
    Array.Sort(digit1);
    Array.Sort(digit2);
    Array.Sort(digit3);
    Array.Sort(digit4);
    Array.Sort(digit5);
    Array.Sort(digit6);
    Array.Sort(digit7);
    Array.Sort(digit8);
    Array.Sort(digit9);
    var segment = new List<string>{ string.Join("",digit0),
        string.Join("", digit1), string.Join("", digit2), string.Join("", digit3), 
        string.Join("", digit4), string.Join("", digit5), string.Join("", digit6), 
        string.Join("", digit7), string.Join("", digit8), string.Join("", digit9) };

    string outval = "";
    foreach (var item in output)
    {
        Array.Sort(item);
        var itm = string.Join("", item);
        outval += segment.IndexOf(itm);
    }
    sum += int.Parse(outval);
}
Console.WriteLine("Part 2: " +sum);