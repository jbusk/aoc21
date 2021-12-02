// See https://aka.ms/new-console-template for more information
using (var sr = new StreamReader("input.txt"))
{
    // Del 1
    //int increasecount = 0;
    //int previous = int.Parse(sr.ReadLine()!);
    //while (!sr.EndOfStream)
    //{
    //    int current = int.Parse(sr.ReadLine()!);
    //    if (current > previous)
    //        increasecount++;
    //    previous = current;
    //}
    //Console.WriteLine(increasecount);

    // Del 2
    int count = 0;
    int line0 = int.Parse(sr.ReadLine()!);
    int line1 = int.Parse(sr.ReadLine()!);
    int line2 = int.Parse(sr.ReadLine()!); 
    int lastsum = line0 + line1 + line2;
    line0 = line1;
    line1 = line2;

    int currsum;
    while (!sr.EndOfStream)
    {
        if (int.TryParse(sr.ReadLine(), out int current))
        {
            line2 = current;
            currsum = line0 + line1 + line2;
            if (lastsum < currsum)
                count++;
            lastsum = currsum;
            line0 = line1;
            line1 = line2;
        }


        //Console.WriteLine($"current = {current} sumA = {sumA} countA = {countA} sumB = {sumB} countB = {countB} sumC = {sumC} countC = {countC}");
    }


    Console.WriteLine(count);
}