using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Board
    {

        public char[,] Cell;
        public int Rows;
        public int Columns;


        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cell = new char[rows, columns];
            for (int l = 0; l < Rows; l++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Cell[l, c] =' ';
                }
            }
        }

        public void InitBoard()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Cell[i, j] = ' ';
                }
            }

        }

        public char GetCell(Position position)
        {
            return Cell[position.x, position.y];
        }


        public void CheckPosition(Position position)
        {
            if (position.x < 0 || position.x >= Rows)
            {
                throw new ArgumentOutOfRangeException(nameof(position.x), "La ligne est en dehors du plateau.");
            }

            if (position.y < 0 || position.y >= Columns)
            {
                throw new ArgumentOutOfRangeException(nameof(position.y), "La colonne est en dehors du plateau.");
            }
        }


        public bool IsFull(Position position)
        {
            if (GetCell(position) != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlaceSymbole(Position position, char symbole)
        {
            if(!IsFull(position))
            {
                Cell[position.x, position.y] = symbole;
            }
        }
        public void DrawBoard(int Rows,int Columns)
        {
            Console.Clear();
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (column > 0)
                        Console.Write("+");

                    Console.Write(new string('-', + 3));
                }
                Console.WriteLine();
                for (int l = 0; l < 4; l++)
                {
                    for (int c = 0; c < Columns; c++)
                    {
                        if (c > 0)
                            Console.Write("|");
                        var spaces = new string(' ', 3 / 2);
                        var piece = Cell[row, c];
                        var pieceString = piece.ToString() ?? " ";
                        var separator = l == 2 / 2 ? pieceString : " ";
                        Console.Write($"{spaces}{separator}{spaces}");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
