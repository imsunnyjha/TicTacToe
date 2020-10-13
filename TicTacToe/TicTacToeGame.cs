using System;
using System.ComponentModel;
using System.Data.Common;

namespace TicTacToe
{
    class TicTacToeGame
    {
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
            if (choice == 'X' || choice == 'O' || choice == 'x' || choice == 'o')
            {
                return choice;
            }
            ChooseUserLetter();
            return ' ';
        }
        public void ShowBoard()
        {
            for (int space = 1; space < 10; space++)
            {
                if (space == 4 || space == 7)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("    -------------------");
                }
                Console.Write(board[space] + "     |");
            }
        }

        public int GetUserMove()
        {
            Console.WriteLine("\nYour Turn: ");
            int index = Convert.ToInt32(Console.ReadLine());
            if(index<1 || index > 9)
            {
                Console.WriteLine("Oops! Please enter valid entry!");
                GetUserMove();
            }
            if(board[index]!=' ')
            {
                Console.WriteLine("Oops! That's filled!");
                GetUserMove();
            }
            return index;
        }
        public void MakeAMove(int index,char choice)
        {
            board[index]=choice;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeGame ticTacToe = new TicTacToeGame();
            ticTacToe.CreateBoard();
            char playerLetter = ticTacToe.ChooseUserLetter();
            ticTacToe.ShowBoard();
            int index = ticTacToe.GetUserMove();
            ticTacToe.MakeAMove(index, playerLetter);
        }
    }
}
