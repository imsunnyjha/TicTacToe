﻿using System;
using System.ComponentModel;
using System.Data.Common;

namespace TicTacToe
{
    class TicTacToeGame
    {
        public const int USER = 0;
        public const int COMPUTER = 1;

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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            TicTacToeGame ticTacToe = new TicTacToeGame();
            ticTacToe.CreateBoard();
            string player = ticTacToe.PlayerStartingFirst();
            while (true)
            {
                Console.WriteLine(player + " plays");
                char playerLetter = ticTacToe.ChooseUserLetter();
                int location = ticTacToe.MoveToLocation();
                ticTacToe.MakeAMove(location, playerLetter);
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
