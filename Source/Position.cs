using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int row, int column)
        {
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "La ligne ne peut pas être négative.");
            }

            if (column < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column), "La colonne ne peut pas être négative.");
            }
            x = row;
            y = column;
        }

    }

}
