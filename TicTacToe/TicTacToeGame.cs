using System;
using System.ComponentModel;
using System.Data.Common;

namespace TicTacToe
{
    class TicTacToeGame
    {
        public const int USER = 1;
        public const int COMPUTER = 0;

        char[] board;
        public TicTacToeGame()
        {
            board = new char[10];
        }
        public void CreateBoard()
        {
            for (int space = 1; space <= 9; space++)
            {
                board[space] = ' ';
            }
        }
        public char ChooseUserLetter()
        {
            char choice;
            Console.WriteLine("Play as X or O : ");
            choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'X' || choice == 'O')
            {
                return choice;
            }
            ChooseUserLetter();
            return ' ';
        }
        public char getComputerLetter(char playerLetter)
        {
            if (playerLetter == 'X')
                return 'O';
            return 'X';
        }
        public void ShowBoard()
        {
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[1], board[2], board[3]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[4], board[5], board[6]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", board[7], board[8], board[9]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        }

        public int MoveToLocation()
        {
            Console.WriteLine("Enter Location index from 1 to 9");
            int location = Convert.ToInt32(Console.ReadLine());
            if (location < 1 || location > 9)
            {
                Console.WriteLine("Not valid index");
                MoveToLocation();

            }
            if (isSpaceFree(location) == false)
            {
                Console.WriteLine("Location already filled");
                MoveToLocation();
            }
            return location;

        }
        public bool isSpaceFree(int location)
        {
            return (board[location] == ' ');

        }
        public void MakeAMove(int location,char letter)
        {
            board[location]=letter;
        }
        public string PlayerStartingFirst()
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            if (toss == USER)
            {
                return "USER";
            }
            return "COMPUTER";
        }
        public string PlayerChance(string player)
        {
            if (player == "USER")
            {
                return "COMPUTER";
            }
            return "USER";
        }
        public bool CheckWinner(char playerLetter)
        {
            return ((board[1] == playerLetter && board[2] == playerLetter && board[3] == playerLetter) ||
                    (board[1] == playerLetter && board[4] == playerLetter && board[7] == playerLetter) ||
                    (board[1] == playerLetter && board[5] == playerLetter && board[9] == playerLetter) ||
                    (board[3] == playerLetter && board[6] == playerLetter && board[9] == playerLetter) ||
                    (board[3] == playerLetter && board[5] == playerLetter && board[7] == playerLetter) ||
                    (board[7] == playerLetter && board[8] == playerLetter && board[9] == playerLetter)
                   );
        }
        public bool CheckDraw()
        {
            for (int i = 0; i <= 9; i++)
            {
                if (isSpaceFree(i) == true)
                    return false;
            }
            return true;
        }
        public int GetComputerMove(char computerLetter, char playerLetter)
        {
            int winningMove = GetWinningMove(computerLetter);
            if (winningMove != 0)
                return winningMove;
            int playerWinningMove = GetWinningMove(playerLetter);
            if (playerWinningMove != 0)
                return playerWinningMove;
            int[] cornerMoves = { 1, 3, 7, 9 };
            for (int i = 0; i < cornerMoves.Length; i++)
            {
                if (isSpaceFree(i))
                    return cornerMoves[i];
            }
            if (isSpaceFree(5))
                return 5;
            int[] sideMoves = { 2, 4, 6, 8 };
            for (int i = 0; i < sideMoves.Length; i++)
            {
                if (isSpaceFree(i))
                    return sideMoves[i];
            }
            return 0;
        }
        public int GetWinningMove(char computerLetter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (isSpaceFree(i))
                {
                    MakeAMove(i, computerLetter);
                    if (CheckWinner(computerLetter))
                    {
                        board[i] = ' ';
                        return i;
                    }
                    board[i] = ' ';
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            int location = 0;

            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeGame ticTacToe = new TicTacToeGame();
            ticTacToe.CreateBoard();
            char playerLetter = ticTacToe.ChooseUserLetter();
            char computerLetter = ticTacToe.getComputerLetter(playerLetter);
            string player = ticTacToe.PlayerStartingFirst();
            while (true)
            {
                Console.WriteLine(player + " plays");
                if (player == "USER")
                {
                    location = ticTacToe.MoveToLocation();
                    ticTacToe.MakeAMove(location, playerLetter);
                }
                if (player == "COMPUTER")
                {
                    location = ticTacToe.GetComputerMove(computerLetter,playerLetter);
                    ticTacToe.MakeAMove(location, computerLetter);
                }
                ticTacToe.ShowBoard();
                if (ticTacToe.CheckWinner(playerLetter) == true)
                {
                    Console.WriteLine(player + " Has Won");
                    break;
                }
                if (ticTacToe.CheckDraw())
                {
                    Console.WriteLine("It's a tie");
                    break;
                }
                player = ticTacToe.PlayerChance(player);
            }
        }
    }
}
