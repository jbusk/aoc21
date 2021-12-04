using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc04
{
    internal class BingoBoard
    {
        public BingoBoard(string board)
        {
            var grid = new List<GameField>();
            foreach (var item in System.Text.RegularExpressions.Regex.Split(board, @"\s+"))
            {
                int value = int.Parse(item);
                grid.Add(new GameField(int.Parse(item)));
            }
            Grid = grid;
        }
        public List<GameField> Grid { get; set; }
        public bool Won
        {
            get
            {
                // check vertical
                for (int i = 0; i < 5; i++)
                {
                    if (Grid[i].Called && Grid[i + 5].Called && Grid[i + 10].Called && Grid[i + 15].Called && Grid[i + 20].Called)
                        return true;
                }
                // check horizontal
                for (int i = 0; i < 25; i = i + 5)
                {
                    if (Grid[i].Called && Grid[i + 1].Called && Grid[i + 2].Called && Grid[i + 3].Called && Grid[i + 4].Called)
                        return true;
                }
                return false;
            }
        }

        public bool Call(int number)
        {
            var gameField = Grid.Find(x => x.Value == number);
            if (gameField == null)
                return false;
            gameField.Called = true;
            return Won;
        }

        public int Sum
        {
            get
            {
                return Grid.FindAll(x => !x.Called).Sum(u => u.Value);
            }
        }

        public override string ToString()
        {
            string retval = "";
            for (int i = 0; i < 25; i = i + 5)
            {
                retval += $"{Grid[i]} {Grid[i + 1]} {Grid[i + 2]} {Grid[i + 3]} {Grid[i + 4]}\n";
            }
            return retval;
        }

    }

    internal class GameField
    {
        public GameField(int value)
        {
            Value = value;
            Called = false;
        }
        public int Value { get; set; }
        public bool Called { get; set; }

        public override string ToString()
        {
            return $"{Value}" + (Called ? "!" : "");
        }
    }
}
