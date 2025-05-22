using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public string[,] Grid { get; set; } = new string[3, 3];
        public string CurrentRound { get; set; } = "O";

        public void PlayRound(string cords) {
            cords = cords.ToLower();

            int x = GridDictionary[cords[0]];
            int y = Int32.Parse(cords[1].ToString());

            Grid[x, y] = CurrentRound;

            CurrentRound = GetNextRound();
        }
        private static Dictionary<char, int> GridDictionary = new Dictionary<char, int>() {
            {'a', 0 },
            {'b', 1 },
            {'c', 2 },
        };
        private string GetNextRound() {
            if (CurrentRound == "O") return "X";
            return "O";
        }

        public WinnerType GetWinner() {
            List<Line> lines = Line.GetListFromGrid(Grid);

            foreach (Line line in lines) {
                WinnerType winner = line.GetWinner();

                if (winner == WinnerType.X || winner == WinnerType.O) return winner;
            }

            //Check for tie
            for (int y = 0; y < 3; y++) {
                for (int x = 0; x < 3; x++) {
                    if (string.IsNullOrEmpty(Grid[x, y])) return WinnerType.None;
                }
            }

            return WinnerType.Tie;
        }
    }

    struct Line {
        public string[] Cells { get; set; }

        public Line(params string[] cells) {
            Cells = cells;
        }

        public static List<Line> GetListFromGrid(string[,] grid){
            Line l0 = new Line(grid[0, 0], grid[1, 0], grid[2, 0]);
            Line l1 = new Line(grid[2, 0], grid[2, 1], grid[2, 2]);
            Line l2 = new Line(grid[0, 2], grid[1, 2], grid[2, 2]);
            Line l3 = new Line(grid[0, 0], grid[0, 1], grid[0, 2]);
            Line l4 = new Line(grid[0, 1], grid[1, 1], grid[2, 1]);
            Line l5 = new Line(grid[1, 0], grid[1, 1], grid[1, 2]);
            Line l6 = new Line(grid[0, 0], grid[1, 1], grid[2, 2]);
            Line l7 = new Line(grid[0, 2], grid[1, 1], grid[2, 0]);

            return new List<Line>() { l0, l1, l2, l3, l4, l5, l6, l7 };
        }
        public WinnerType GetWinner() {
            string sum = String.Join("", Cells);
            if (sum != "OOO" && sum != "XXX") return WinnerType.None;

            if (sum == "OOO") return WinnerType.O;
            return WinnerType.X;
        }
    }

    public enum WinnerType { 
        O,
        X,
        Tie,
        None
    }
}
