namespace aoc11;
internal class Octopus
{
    public Octopus(char energy)
    {
        Energy = int.Parse(energy.ToString());
        Flashed = false;
    }

    public int Energy { get; set; }

    public bool Flashed { get; set; }

    public bool WillFlash
    {
        get
        {
            if (Energy > 9 && !Flashed)
                return true;
            return false;
        }
    }

    public void Increase()
    {
        if (Flashed)
            Energy = 0;
        Energy++;
        Flashed = false;
    }

    public override string ToString()
    {
        return (Energy > 9 ? "0" : Energy.ToString());
    }

}
