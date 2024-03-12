using System;
using System.Collections.Generic;

namespace MorpionApp
{
    public abstract class Game
    {
        private const int WidthCase = 3;
        private const int HeightCase = 4;

        public List<Player> Players = new List<Player> { new Player("Joueur 1", 'X'), new Player("Joueur 2", 'O') };
        public Player CurrentPlayer;
        public int NextPlayerId = 0;

        public int row = 0;
        public int column = 0;
        public bool quit = false;

        protected readonly int Rows;
        protected readonly int Columns;
        protected readonly int NumberForWin;
        protected readonly Board board;

        public Game(int rows, int columns, int numberForWin)
        {
            Rows = rows;
            Columns = columns;
            NumberForWin = numberForWin;
            board = new Board(rows, columns);
        }

        public virtual void InputManager(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    GoRight();
                    break;
                case ConsoleKey.LeftArrow:
                    GoLeft();
                    break;
                case ConsoleKey.UpArrow:
                    GoUp();
                    break;
                case ConsoleKey.DownArrow:
                    GoDown();
                    break;
                case ConsoleKey.Enter:
                    Place();
                    break;
                case ConsoleKey.Escape:
                    quit = Quit();
                    break;
                default:
                    break;
            }
        }

        public void GoRight()
        {
            column = (column + 1) % Columns;
        }

        public void GoLeft()
        {
            int col = Columns - 1;
            column = (column + col) % Columns;
        }

        public void GoUp()
        {
            int li = Rows - 1;
            row = (row + li) % Rows;
        }

        public void GoDown()
        {
            row = (row + 1) % Rows;
        }

        protected virtual bool Quit()
        {
            Console.WriteLine("Voulez-vous enregistrer le jeu ?");
            return true;
        }

        public virtual void Place()
        {
            Position position = new Position(row, column);
            if (!board.IsFull(position))
            {
                board.PlaceSymbole(position, CurrentPlayer.Symbole);
                NextPlayerId = (NextPlayerId + 1) % Players.Count;
            }
        }

        public void GameLoop()
        {
            CurrentPlayer = Players[0];
            board.InitBoard();
            while (!quit)
            {
                board.DrawBoard(Rows, Columns);
                Console.WriteLine("Choisir une case valide et appuyer sur [Entrer]");

                Console.SetCursorPosition(column * (WidthCase + 1) + WidthCase / 2, row * (HeightCase + 1) + HeightCase / 2);
                ConsoleKey saisie = Console.ReadKey(true).Key;
                InputManager(saisie);
                if (CheckVictory())
                {
                    Console.Clear();
                    ShowWinner();
                    quit = true;
                    Console.WriteLine("Appuyez sur entrer pour revenir au menu");
                    Console.ReadLine();
                }
                else if (CheckEquality())
                {
                    Console.Clear();
                    board.DrawBoard(Rows, Columns);
                    Console.WriteLine("Egalité");
                    quit = true;
                    Console.WriteLine("Appuyez sur entrer pour revenir au menu");
                    Console.ReadLine();
                }
                CurrentPlayer = Players[NextPlayerId];
            }
        }

        private void ShowWinner()
        {
            board.DrawBoard(Rows, Columns);
            Console.WriteLine("Le joueur " + CurrentPlayer.Name + " a gagné !");
        }

        public abstract bool CheckEquality();

        public abstract bool CheckVictory();
    }
}
