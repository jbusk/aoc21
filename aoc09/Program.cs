string? first = null ;
string? second = null;
string? current = null;
int pt1sum = 0;
using (var sr = new StreamReader("input.txt"))
{
    bool lastline = false;
    while (!sr.EndOfStream)
    {
        current = sr.ReadLine()!;
        if (string.IsNullOrEmpty(current))
            lastline = true;
        if (second != null)
        {
            for (int i = 0; i < second.Length; i++)
            {
                if (lastline || second[i] < current[i]) {
                    if (first == null || second[i] < first[i])
                    {
                        if ((i == 0 || second[i] < second[i-1]))
                        {
                            if ((i == second.Length -1 || second[i] < second[i+1]))
                            {
                                pt1sum += 1 + int.Parse(second[i].ToString());
                            }
                        }
                    }
                }
            }
        }
        first = second;
        second = current;
    }
}
Console.WriteLine("Part 1: " + pt1sum);