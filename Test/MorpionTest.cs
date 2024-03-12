using MorpionApp;

namespace Test
{
    public class MorpionTest
    {
        [Fact]
        public void TestVerifVictoireLigne()
        {
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', 'X', 'X'},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
            };
            Assert.True(morpion.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifVictoireColonne()
        {
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', ' ', ' '},
                { 'X', ' ', ' '},
                { 'X', ' ', ' '},
            };
            Assert.True(morpion.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifVictoireDiagonale()
        {
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', ' ', ' '},
                { ' ', 'X', ' '},
                { ' ', ' ', 'X'},
            };
            Assert.True(morpion.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifVictoireEgaliter()
        {
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', 'O', 'X'},
                { 'X', 'O', 'O'},
                { 'O', 'X', 'X'},
            };
            Assert.False(morpion.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifEgalite()
        {
            Morpion morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                { 'X', 'O', 'X'},
                { 'X', 'O', 'O'},
                { 'O', 'X', 'X'},
            };
            Assert.True(morpion.verifEgalite());
        }
    }
}