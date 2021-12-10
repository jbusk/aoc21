int pt1sum = 0;
List<long> pt2sums = new();
using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!.ToCharArray();
        var stack = new Stack<char>();
        bool corrupt_line = false;
        foreach (var item in line)
        {
            //Console.WriteLine(  item);
            switch (item)
            {
                case '(':
                case '[':
                case '{':
                case '<':
                    stack.Push(item);
                    break;
                case ')':
                    if (stack.Pop() != '(')
                    {
                        pt1sum += 3;
                        corrupt_line = true;
                    }
                    break;
                case ']':
                    if (stack.Pop() != '[')
                    {
                        pt1sum += 57;
                        corrupt_line = true;
                    }
                    break;
                case '}':
                    if (stack.Pop() != '{')
                    {
                        pt1sum += 1197;
                        corrupt_line = true;
                    }
                    break;
                case '>':
                    if (stack.Pop() != '<')
                    {
                        pt1sum += 25137;
                        corrupt_line = true;
                    }
                    break;
                default:
                    break;
            }
            if (corrupt_line)
                break;
        }
        if (corrupt_line)
            continue;
        long sum = 0;
        while (stack.Count > 0)
        {
            sum *= 5;
            switch (stack.Pop())
            {
                case '(':
                    sum += 1;
                    break;
                case '[':
                    sum += 2;
                    break;
                case '{':
                    sum += 3;
                    break;
                case '<':
                    sum += 4;
                    break;
                default:
                    break;
            }
        }
        pt2sums.Add(sum);
    }
}
pt2sums.Sort();
Console.WriteLine("Part 1 " + pt1sum);
Console.WriteLine("Part 2 " + pt2sums[pt2sums.Count/2]);