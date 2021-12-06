namespace aoc06
{
    internal class Fish
    {
        public Fish()
        {
            Counter = 8;
            Amount = 1;
        }
        public Fish(int counter)
        {
            Counter = counter;
            Amount = 1;
        }
        public Fish(int counter, long amount)
        {
            Counter=counter;
            Amount=amount;
        }
        public int Counter { get; set; }

        public long Amount { get; set; }
        public long Day()
        {
            if (Counter == 0)
            {
                Counter = 6;
                return Amount;
            }
            Counter--;
            return 0;
        }
        public void AddAmount(int amount)
        {
            Amount += amount;
        }

        public override string ToString()
        {
            return $"({Amount},{Counter})";
        }
    }
}
