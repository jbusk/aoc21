namespace aoc09
{
    internal class Location
    {
        public Location(int depth, int north, int south, int west, int east)
        {
            Depth = depth;
            North = north;
            South = south;
            West = west;
            East = east;
            if (depth == 9)
                Basin = false;
            else
                Basin = true;
        }
        public int Depth { get; set; }
        public int North { get; set; }
        public int South { get; set; }
        public int West { get; set; }
        public int East { get; set; }

        public bool Basin { get; set; }
    }
}
