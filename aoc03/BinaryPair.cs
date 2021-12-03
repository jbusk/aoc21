﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc03
{
    internal class BinaryPair
    {
        public BinaryPair()
        {
            Zero = 0;
            One = 0;
        }

        public BinaryPair(int val)
        {
            Zero = 0;
            One = 0;
            Add(val);
        }

        public int Zero { get; set; }
        public int One { get; set; }

        public void Add(int val)
        {
            if (val == 0)
                AddZero();
            else if (val == 1)
                AddOne();
        }

        public void AddZero()
        {
            Zero++;
        }

        public void AddOne()
        {
            One++;
        }

        override public string ToString()
        {
            return $"1:{One} 0:{Zero}";
        }

        public int Max()
        {
            if (Zero > One)
                return 0;
            else
                return 1;
        }

        public int Min()
        {
            return Max() ^ 1;
        }
    }
}
