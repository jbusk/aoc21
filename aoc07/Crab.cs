namespace aoc07
{
    internal class Crab
    {
        public Crab(int position)
        {
            Position = position;
            Amount = 1;
        }

        public int Position { get; set; }
        public int Amount { get; set; }
        public int Pt1Align(int requested)
        {
            return Amount * Math.Abs(Position - requested);
        }
        public int Pt2Align(int requested)
        {
            int diff = Math.Abs(Position - requested);
            return Amount * (diff * (diff + 1)/2);
        }
        public override string ToString()
        {
            return $"({Position}:{Amount})";
        }
    }
}
