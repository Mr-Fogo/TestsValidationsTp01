using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Power4() : Game(6, 7, 4)
    {
        public override bool CheckEquality()
        {
            int comp = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int colonne = 0; colonne < Columns; colonne++)
                {
                    if (board.Cell[row,colonne] != ' ')
                    {
                        comp++;
                    }
                }
            }
            if (comp == Rows * Columns)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                if (IsDiagonaleWinnable())
                {
                    return true;
                }
            }
            return false;

        }

        private bool IsRowWinnable(int row)
        {
            int numberComboWin = 0;

            for (int column = 0; column < Columns; column++)
            {
                if (board.Cell[row,column] == CurrentPlayer.Symbole)
                {
                    numberComboWin++;
                    if (numberComboWin == NumberForWin)
                    {
                        return true;
                    }
                }
                else
                {
                    numberComboWin = 0;
                }
            }

            return false;
        }
        private bool IsColumnWinnable(int column)
        {
            int numberComboWin = 0;

            for (int row = 0; row < Rows; row++)
            {
                if (board.Cell[row, column] == CurrentPlayer.Symbole)
                {
                    numberComboWin++;
                    if (numberComboWin == NumberForWin)
                    {
                        return true;
                    }
                }
                else
                {
                    numberComboWin = 0;
                }
            }

            return false;
        }
        private bool IsDiagonaleWinnable()
        {
            return IsDiagonaleDownWinnable() || IsDiagonaleUpWinnable();
        }

        private bool IsDiagonaleUpWinnable()
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
        private bool IsDiagonaleDownWinnable()
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

        public override void InputManager(ConsoleKey cle)
        {
            switch (cle)
            {
                case ConsoleKey.RightArrow:
                    GoRight();
                    break;
                case ConsoleKey.LeftArrow:
                    GoLeft();
                    break;
                case ConsoleKey.Enter:
                    Place();
                    break;
                case ConsoleKey.Escape:
                    Quit();
                    break;
                default:
                    break;
            }
        }
        private bool IsColumnFull(int colonne)
        {
            for (int ligne = 0; ligne < Rows; ligne++)
            {
                if (!board.IsFull(new Position(ligne, colonne)))
                {
                    return false;
                }
            }
            return true;
        }
        public override void Place()
        {
            Position position = new(row, column);
            if (!IsColumnFull(column))
            {
                for (int ligne = Rows - 1; ligne >= 0; ligne--)
                {
                    if (!board.IsFull(new Position(ligne, column)))
                    {
                        position = new Position(ligne, column);
                        break;
                    }
                }

                board.PlaceSymbole(position, CurrentPlayer.Symbole);
                NextPlayerId = (NextPlayerId + 1) % Players.Count;
            }
        }
    }
}
