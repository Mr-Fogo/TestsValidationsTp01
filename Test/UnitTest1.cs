using MorpionApp;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void VerifVictoire_Player1Wins_ReturnsTrue()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { 'X', ' ', ' ' },
                { 'X', ' ', ' ' },
            };

            // Act
            var result = morpion.verifVictoire('X');

            // Assert
            Assert.True(result);
        }
    }
}