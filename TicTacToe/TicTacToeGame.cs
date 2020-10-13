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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeGame ticTacToe = new TicTacToeGame();
            ticTacToe.CreateBoard();
        }

    }
}
