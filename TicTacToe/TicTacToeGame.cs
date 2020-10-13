using System;

namespace TicTacToe
{
    class TicTacToeGame
    {
        char[] boardSize;
        public TicTacToeGame()
        {
            boardSize = new char[10];
        }
        public void CreateBoard()
        {
            for (int space = 1; space <= 9; space++)
            {
                boardSize[space] = ' ';
            }
        }
        private static char chooseUserLetter()
        {
            Console.WriteLine("X or O : ");
            string userLetter = Console.ReadLine();
            return char.ToUpper(userLetter[0]);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeGame ticTacToe = new TicTacToeGame();
            ticTacToe.CreateBoard();
            char userLetter = chooseUserLetter();
        }

    }
}
