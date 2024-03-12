using System;

namespace MorpionApp
{
    public class Morpion : Game
    {
        public Morpion() : base(3, 3, 3)
        {
        }

        public override bool CheckEquality()
        {
            int comp = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (board.Cell[row, column] != ' ')
                    {
                        comp++;
                    }
                }
            }
            return comp == Rows * Columns;
        }

        public override bool CheckVictory()
        {
            for (int row = 0; row < Rows; row++)
            {
                if (IsRowWinnable(row))
                {
                    return true;
                }
            }

            for (int column = 0; column < Columns; column++)
            {
                if (IsColumnWinnable(column))
                {
                    return true;
                }
            }

            for (int i = 1; i <= 2; i++)
            {
                if (IsDiagonalWinnable())
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDiagonalWinnable()
        {
            return IsUpDiagonalWinnable() || IsDownDiagonalWinnable();
        }

        public bool IsUpDiagonalWinnable()
        {
            for (int row = NumberForWin - 1; row < Rows; row++)
            {
                for (int column = 0; column <= Columns - NumberForWin; column++)
                {
                    bool win = true;
                    for (int k = 0; k < NumberForWin; k++)
                    {
                        if (board.Cell[row - k, column + k] != CurrentPlayer.Symbole)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                        return true;
                }
            }
            return false;
        }

        public bool IsDownDiagonalWinnable()
        {
            for (int row = 0; row <= Rows - NumberForWin; row++)
            {
                for (int column = 0; column <= Columns - NumberForWin; column++)
                {
                    bool win = true;
                    for (int k = 0; k < NumberForWin; k++)
                    {
                        if (board.Cell[row + k, column + k] != CurrentPlayer.Symbole)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                        return true;
                }
            }
            return false;
        }

        public bool IsColumnWinnable(int column)
        {
            int numberComboWin = 0;

            for (int row = 0; row < Rows; row++)
            {
                if (board.Cell[row, column] == CurrentPlayer.Symbole)
                {
                    numberComboWin++;
                }
            }

            return numberComboWin == NumberForWin;
        }

        public bool IsRowWinnable(int row)
        {
            int nbCasesGagnantes = 0;

            for (int column = 0; column < Columns; column++)
            {
                if (board.Cell[row, column] == CurrentPlayer.Symbole)
                {
                    nbCasesGagnantes++;
                }
            }

            return nbCasesGagnantes == NumberForWin;
        }
    }
}
