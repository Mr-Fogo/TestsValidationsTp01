using MorpionApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class PuissanceTest
    {
        [Fact]
        public void CheckEqualityTest()
        {
            Power4 power4 = new Power4();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    power4.board.Cell[i, j] = 'X';
                }
            }
            Assert.True(power4.CheckEquality());

        }
        [Fact]
        public void CheckVictoryTest()
        {
            Power4 power4 = new Power4();
            power4.board.InitBoard();
            power4.CurrentPlayer = power4.Players[0];
            for (int i = 0; i < 4; i++)
            {
                power4.board.Cell[0, i] = 'X';
            }
            Assert.True(power4.CheckVictory());
        }
        [Fact]
        public void IsRowWinnableTest()
        {
            Power4 power4 = new Power4();
            power4.CurrentPlayer = power4.Players[0];
            power4.board.InitBoard();
            for (int i = 0; i < 4; i++)
            {
                power4.board.Cell[0, i] = 'X';
            }
            Assert.True(power4.IsRowWinnable(0));
        }
        [Fact]
        public void IsDiagonalWinnableTest()
        {
            Power4 power4 = new Power4();
            power4.CurrentPlayer = power4.Players[0];
            power4.board.Cell[0, 0] = 'X';
            power4.board.Cell[1, 1] = 'X';
            power4.board.Cell[2, 2] = 'X';
            power4.board.Cell[3, 3] = 'X';
            Assert.True(power4.IsDiagonaleWinnable());
        }
        [Fact]
        public void IsColumnWinnableTest()
        {
            Power4 power4 = new Power4();
            power4.CurrentPlayer = power4.Players[0];
            power4.board.InitBoard();
            for (int i = 0; i < 4; i++)
            {
                power4.board.Cell[i, 0] = 'X';
            }
            Assert.True(power4.IsColumnWinnable(0));
        }
        [Fact]
        public void IsUpDiagonalWinnableTest()
        {
            Power4 power4 = new Power4();
            power4.CurrentPlayer = power4.Players[0];
            power4.board.Cell[3, 0] = 'X';
            power4.board.Cell[2, 1] = 'X';
            power4.board.Cell[1, 2] = 'X';
            power4.board.Cell[0, 3] = 'X';
            Assert.True(power4.IsDiagonaleUpWinnable());
        }
        [Fact]
        public void IsDownDiagonalWinnableTest()
        {
            Power4 power4 = new Power4();
            power4.CurrentPlayer = power4.Players[0];
            power4.board.Cell[0, 0] = 'X';
            power4.board.Cell[1, 1] = 'X';
            power4.board.Cell[2, 2] = 'X';
            power4.board.Cell[3, 3] = 'X';
            Assert.True(power4.IsDiagonaleDownWinnable());
        }

        [Fact]
        public void IsColumnFull()
        {
            Power4 power4 = new Power4();
            power4.board.InitBoard();
            for (int i = 0; i < 6; i++)
            {
                power4.board.Cell[i, 0] = 'X';
            }
            Assert.True(power4.IsColumnFull(0));
        }






    }
}
