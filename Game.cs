using CommonConsoleAppMethods;
using System.Drawing;
using System.Text;

namespace ConnectFour
{
    internal class Game
    {
        static Board board = Board.GetBoard();
        static Player redPlayer;
        static Player yellowPlayer;
        static bool turn = true;
        static int[] colProgress = new int[7];
        static List<int> filledCols = [];

        static string redCircle = "🔴";
        static string yellowCircle = "🟡";

        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            redPlayer = new(Methods.GetName("RED player name"), Color.Red, "RED", redCircle);
            yellowPlayer = new(Methods.GetName("YELLOW player name"), Color.Yellow, "YELLOW", yellowCircle);
            DisplayTurn();
            board.DisplayBoard();
            bool win;
            do
            {
                win = Turn();
            } while (!win);
            Console.ReadLine();
        }
        private static Player CurrentPlayer()
        {
            return turn == true ? redPlayer : yellowPlayer;
        }
        public static void DisplayTurn()
        {
            Console.WriteLine($"\t    {CurrentPlayer().colorName} to move");
        }
        public static bool Turn()
        {
            int col = Methods.GetNumber2(1, 7, "Choose a column 1 - 7", exceptions: [.. filledCols]);
            colProgress[col - 1]++;
            if (colProgress[col - 1] == 6)
            {
                filledCols.Add(col);
            }
            board.slots[col - 1, 6 - (colProgress[col - 1])].color = CurrentPlayer().colorIcon;
            bool win = CheckForWinner(CurrentPlayer().colorIcon);
            Methods.ClearFullConsole();

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            if (win)
            {
                Console.WriteLine($"{CurrentPlayer().name} WINS!!!");
            }
            else
            {
                turn = !turn;
                DisplayTurn();
            }
            board.DisplayBoard();

            return win;
        }
        public static bool CheckForWinner(string currentPlayerColor)
        {
            // rows
            for (int i = 0; i < board.slots.GetLength(0); i++)
            {
                for (int j = 0; j < board.slots.GetLength(1) - 3; j++)
                {
                    if (board.slots[i, j].color == currentPlayerColor
                        && board.slots[i, j + 1].color == currentPlayerColor
                        && board.slots[i, j + 2].color == currentPlayerColor
                        && board.slots[i, j + 3].color == currentPlayerColor)
                    {
                        return true;
                    }
                }
            }
            // columns
            for (int i = 0; i < board.slots.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < board.slots.GetLength(1); j++)
                {
                    if (board.slots[i, j].color == currentPlayerColor
                        && board.slots[i + 1, j].color == currentPlayerColor
                        && board.slots[i + 2, j].color == currentPlayerColor
                        && board.slots[i + 3, j].color == currentPlayerColor)
                    {
                        return true;
                    }
                }
            }
            // diagonal top-left to bottom-right
            for (int i = 0; i < board.slots.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < board.slots.GetLength(1) - 3; j++)
                {
                    if (board.slots[i, j].color == currentPlayerColor
                        && board.slots[i + 1, j + 1].color == currentPlayerColor
                        && board.slots[i + 2, j + 2].color == currentPlayerColor
                        && board.slots[i + 3, j + 3].color == currentPlayerColor)
                    {
                        return true;
                    }
                }
            }
            // diagonal top-right to bottom-left
            for (int i = 3; i < board.slots.GetLength(0); i++)
            {
                for (int j = 0; j < board.slots.GetLength(1) - 3; j++)
                {
                    if (board.slots[i, j].color == currentPlayerColor
                        && board.slots[i - 1, j + 1].color == currentPlayerColor
                        && board.slots[i - 2, j + 2].color == currentPlayerColor
                        && board.slots[i - 3, j + 3].color == currentPlayerColor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
