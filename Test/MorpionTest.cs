using MorpionApp;

namespace Test
{
    public class MorpionTest
    {
        [Fact]
        public void CheckEqualityTest()
        {
            Morpion morpion = new Morpion();
            morpion.board.Cell[0, 0] = 'X';
            morpion.board.Cell[0, 1] = 'O';
            morpion.board.Cell[0, 2] = 'X';
            morpion.board.Cell[1, 0] = 'O';
            morpion.board.Cell[1, 1] = 'X';
            morpion.board.Cell[1, 2] = 'O';
            morpion.board.Cell[2, 0] = 'X';
            morpion.board.Cell[2, 1] = 'O';
            morpion.board.Cell[2, 2] = 'X';
            Assert.True(morpion.CheckEquality());
        }
        [Fact]
        public void CheckVictoryTest()
        {
            Morpion morpion = new Morpion();
            morpion.board.InitBoard();
            morpion.CurrentPlayer = morpion.Players[0];
            morpion.board.Cell[0, 0] = 'X';
            morpion.board.Cell[0, 1] = 'O';
            morpion.board.Cell[0, 2] = 'X';
            morpion.board.Cell[1, 0] = 'O';
            morpion.board.Cell[1, 1] = 'X';
            morpion.board.Cell[1, 2] = 'O';
            morpion.board.Cell[2, 0] = 'X';
            morpion.board.Cell[2, 1] = 'O';
            morpion.board.Cell[2, 2] = 'X';
            Assert.True(morpion.CheckVictory());
        }
        [Fact]
        public void IsRowWinnableTest()
        {
            Morpion morpion = new Morpion();
            morpion.CurrentPlayer = morpion.Players[0];
            morpion.board.InitBoard();
            morpion.board.Cell[0, 0] = 'X';
            morpion.board.Cell[0, 1] = 'X';
            morpion.board.Cell[0, 2] = 'X';
            Assert.True(morpion.IsRowWinnable(0));
        }
        [Fact]
        public void IsDiagonalWinnableTest()
        {
            Morpion morpion = new Morpion();
            morpion.CurrentPlayer = morpion.Players[0];
            morpion.board.Cell[0, 0] = 'X';
            morpion.board.Cell[1, 1] = 'X';
            morpion.board.Cell[2, 2] = 'X';
            Assert.True(morpion.IsDiagonalWinnable());
        }
        [Fact]
        public void IsDownDiagonalWinnableTest()
        {
            Morpion morpion = new Morpion();
            morpion.CurrentPlayer = morpion.Players[0];
            morpion.board.Cell[0, 0] = 'X';
            morpion.board.Cell[1, 1] = 'X';
            morpion.board.Cell[2, 2] = 'X';
            Assert.True(morpion.IsDownDiagonalWinnable());
        }
        [Fact]
        public void IsUpDiagonalWinnableTest()
        {
            Morpion morpion = new Morpion();
            morpion.CurrentPlayer = morpion.Players[0];
            morpion.board.Cell[0, 2] = 'X';
            morpion.board.Cell[1, 1] = 'X';
            morpion.board.Cell[2, 0] = 'X';
            Assert.True(morpion.IsUpDiagonalWinnable());
        }
    }
}