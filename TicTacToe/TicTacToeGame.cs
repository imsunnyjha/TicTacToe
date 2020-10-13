using System;
using System.ComponentModel;

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
        private static char ChooseUserLetter()
        {
            Console.WriteLine("Play as X or O : ");
            string userLetter = Console.ReadLine();
            Console.WriteLine("You are Player: " + char.ToUpper(userLetter[0]));
            return char.ToUpper(userLetter[0]);
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

        public void GetUserMove(char letter)
        {
            Console.WriteLine("\nYour Turn: ");
            int index = Convert.ToInt32(Console.ReadLine());
            if(index<1 || index > 9)
            {
                Console.WriteLine("Oops! Please enter valid entry!");
                GetUserMove(letter);
            }
            else if(board[index]==' ')
            {
                board[index] = letter;
            }
            else
            {
                Console.WriteLine("Oops! That's filled!");
                GetUserMove(letter);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeGame ticTacToe = new TicTacToeGame();
            ticTacToe.CreateBoard();
            char userLetter = ChooseUserLetter();
            ticTacToe.ShowBoard();
            ticTacToe.GetUserMove(userLetter);
        }
    }
}
