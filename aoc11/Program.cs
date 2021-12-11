using aoc11;

var octopi = new List<Octopus>();
using (var sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine()!.ToCharArray().Select(x => new Octopus(x));
        octopi.AddRange(line);
    }
}

int pt1flashes = 0;
int pt2step = 0;
stringify_octopi();

for (int step = 0; step < 1000; step++)
{
    octopi.ForEach(x => x.Increase());

    int i = octopi.FindIndex(o => o.WillFlash);
    while (i != -1)
    {
        process_octopus(i, false);
        i = octopi.FindIndex(o => o.WillFlash);

        void process_octopus(int i, bool increase = true)
        {
            if (i < 0 || i > 99)
                return;
            var octopus = octopi[i];
            if (octopus.Flashed)
                return;
            if (octopus.WillFlash)
            {
                octopus.Flashed = true;
                switch (i)
                {
                    case 0:
                        process_octopus(i + 1);
                        process_octopus(i + 10);
                        process_octopus(i + 11);
                        break;
                    case 9:
                        process_octopus(i - 1);
                        process_octopus(i + 9);
                        process_octopus(i + 10);
                        break;
                    case 90:
                        process_octopus(i + 1);
                        process_octopus(i - 9);
                        process_octopus(i - 10);
                        break;
                    case 99:
                        process_octopus(i - 1);
                        process_octopus(i - 10);
                        process_octopus(i - 11);
                        break;
                    case 10:
                    case 20:
                    case 30:
                    case 40:
                    case 50:
                    case 60:
                    case 70:
                    case 80:
                        process_octopus(i - 10);
                        process_octopus(i - 9);
                        process_octopus(i + 1);
                        process_octopus(i + 10);
                        process_octopus(i + 11);
                        break;
                    case 19:
                    case 29:
                    case 39:
                    case 49:
                    case 59:
                    case 69:
                    case 79:
                    case 89:
                        process_octopus(i - 1);
                        process_octopus(i - 10);
                        process_octopus(i - 11);
                        process_octopus(i + 9);
                        process_octopus(i + 10);
                        break;
                    default:
                        process_octopus(i - 1);
                        process_octopus(i + 1);
                        process_octopus(i - 9);
                        process_octopus(i + 9);
                        process_octopus(i - 10);
                        process_octopus(i + 10);
                        process_octopus(i - 11);
                        process_octopus(i + 11);
                        break;
                }

            }
            if (increase)
                octopus.Energy++;

        }
    }
    int flashing = octopi.Count(o => o.Flashed);
    if (step < 100)
        pt1flashes += flashing;
    if (flashing == 100)
    {
        pt2step = step + 1;
        break;
    }
    //Console.WriteLine($"After step {step + 1}:");
    //if ((step + 1) % 10 == 0)
    //stringify_octopi();
    //if (step + 1 == 2)
    //    break;

}
Console.WriteLine("Part 1: " + pt1flashes);
Console.WriteLine("Part 2: " + pt2step);
void stringify_octopi()
{
    int num = 0;
    foreach (var o in octopi)
    {
        Console.Write(o);
        if (++num % 10 == 0)
        {
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}