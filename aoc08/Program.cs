using System.Linq;

var file = File.ReadAllText("input.txt").Split('\n').Select(x => x.Split(" | "));
var sum = 0;
foreach (var line in file)
{
    //1, 4, 7, 8 can be figured out
    var input = line[0].Trim().Split(" ").Select(x => x.ToCharArray());
    var output = line[1].Trim().Split(" ").Select(x => x.ToCharArray());
    var array1 = input.Where(x => x.Length == 2).First(); //.ToList();
    // right now c could be f and vice versa
    var seg_c_or_f = array1[0];
    var seg_f_or_c = array1[1];
    var array4 = input.Where(x => x.Length == 4).First();//.ToList();
    var array7 = input.Where(x => x.Length == 3).First();//.ToList();
    var array8 = input.Where(x => x.Length == 7).First();//.ToList();
    var seg_a = array7.Except(array1).First();
    var array3 = input.Where(x => x.Length == 5 && x.Contains(seg_c_or_f) && x.Contains(seg_f_or_c)).First();//.ToList();
    // seg_g är i 3, men inte 4 + seg_a
    var seg_g = array3.Except(array4).Except(new char[] { seg_a }).First();
    // seg_b är i 4 men inte i 3
    var seg_b = array4.Except(array3).First();
    // seg_e är i 8, men inte i 4, och inte a eller g
    var seg_e = array8.Except(array4).Except(new char[] { seg_a, seg_g }).First();
    var array0 = input.Where(x => x.Length == 6 && x.Contains(seg_a) &&
    x.Contains(seg_b) && x.Contains(seg_c_or_f) && x.Contains(seg_e) &&
    x.Contains(seg_f_or_c) && x.Contains(seg_g)).First();//.ToList();
    var seg_d = array8.Except(array0).First();
    var sixes = input.Where(x => x.Length == 6).ToList();
    List<char> array6_cand = new() { ' ' };
    foreach (var item in sixes)
    {
        if (item.Contains(seg_d) && item.Contains(seg_e))
            array6_cand = new List<char>(item);
    }
    // seg_c är i 1 men inte 6
    var seg_c = array1.Except(array6_cand).First();
    // seg_f är i 1 men inte seg_c
    var seg_f = array1.Except(new char[] { seg_c }).First();
    var array2 = input.Where(x => x.Length == 5 && x.Contains(seg_a) && x.Contains(seg_c) && x.Contains(seg_d) && x.Contains(seg_e) && x.Contains(seg_g)).First();//.ToList();
    var array5 = input.Where(x => x.Length == 5 && x.Contains(seg_a) && x.Contains(seg_b) && x.Contains(seg_d) && x.Contains(seg_f) && x.Contains(seg_g)).First();//.ToList();
    var array9 = input.Where(x => x.Length == 6 && x.Contains(seg_a) && x.Contains(seg_b) && x.Contains(seg_c) && x.Contains(seg_d) && x.Contains(seg_f)
    && x.Contains(seg_g)).First();//.ToList();
    var array6 = input.Where(x => x.Length == 6 && x.Contains(seg_a) && x.Contains(seg_b) && x.Contains(seg_d) && x.Contains(seg_e) && x.Contains(seg_f) && x.Contains(seg_g)).First();
    Array.Sort(array0);
    Array.Sort(array1);
    Array.Sort(array2);
    Array.Sort(array3);
    Array.Sort(array4);
    Array.Sort(array5);
    Array.Sort(array6);
    Array.Sort(array7);
    Array.Sort(array8);
    Array.Sort(array9);
    var segment = new List<string>{ string.Join("",array0),
        string.Join("", array1), string.Join("", array2), string.Join("", array3), 
        string.Join("", array4), string.Join("", array5), string.Join("", array6), 
        string.Join("", array7), string.Join("", array8), string.Join("", array9) };

    string outval = "";
    foreach (var item in output)
    {
        Array.Sort(item);
        var itm = string.Join("", item);
        outval += segment.IndexOf(itm);
    }
    sum += int.Parse(outval);
}
Console.WriteLine(sum);