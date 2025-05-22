using System;
using TicTacToe;

namespace TicTacToeUI {
    class Program {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            WinnerType winner = WinnerType.None;
            while (winner == WinnerType.None) {
                Console.Clear();
                DisplayGrid(game.Grid);
                
                Console.Write("Put " + game.CurrentRound + ": ");
                game.PlayRound(Console.ReadLine());

                winner = game.GetWinner();
            }
            DisplayWinner(game, winner);

            Console.ReadLine();
        }

        private static void DisplayGrid(string[,] grid) {
            string seperator = "|";

            Console.WriteLine("   a b c");
            for (int y = 0; y < 3; y++) {
                string line = y + " ";

                for (int x = 0; x < 3; x++) {
                    string c = grid[x, y];
                    c = string.IsNullOrEmpty(c) ? " " : c;

                    line += seperator + c;
                }
                line += seperator;

                Console.WriteLine(line);
            }
        }
        private static void DisplayWinner(Game game, WinnerType winner)
        {
            Console.Clear();
            DisplayGrid(game.Grid);

            string message;

            if (winner == WinnerType.O) message = "The O won!";
            else if (winner == WinnerType.X) message = "The X won!";
            else if (winner == WinnerType.Tie) message = "It's a tie!";
            else message = "No one won";

            Console.WriteLine(message);
        }
    }
}
