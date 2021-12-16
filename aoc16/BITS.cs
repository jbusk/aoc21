namespace aoc16
{
    internal class BITS
    {
        public BITS(string binary)
        {
            Binary = binary;
        }
        public string Binary { get; set; }
        public int Version { get { return Three(Binary.Substring(0, 3)); } }

        public int TypeID { get { return Three(Binary.Substring(3, 3)); } }

        private int Three(string param)
        {
            switch (param)
            {
                case "000":
                    return 0;
                case "001":
                    return 1;
                case "010":
                    return 2;
                case "011":
                    return 3;
                case "100":
                    return 4;
                case "101":
                    return 5;
                case "110":
                    return 6;
                case "111":
                    return 7;
                default:
                    return 0;
            }
        }
    }
}
