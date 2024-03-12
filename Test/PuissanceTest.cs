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
        public void TestVerifVictoireLigne()
        {
            PuissanceQuatre puissance = new PuissanceQuatre();
            puissance.grille = new char[4, 7]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { 'X', 'X', 'X', 'X', ' ', ' ', ' '},
                };
            Assert.True(puissance.verifVictoire('X'));
        }

        [Fact]
        public void TestVerifVictoireColonne()
        {
            PuissanceQuatre puissance = new PuissanceQuatre();
            puissance.grille = new char[4, 7]
                {
                    { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                    { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                    { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                    { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                };
            Assert.True(puissance.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifVictoireDiagonale()
        {
            PuissanceQuatre puissance = new PuissanceQuatre();
            puissance.grille = new char[4, 7]
                {
                    { ' ', ' ', ' ', 'X', ' ', ' ', ' '},
                    { ' ', ' ', 'X', 'O', ' ', ' ', ' '},
                    { ' ', 'X', 'O', 'O', ' ', ' ', ' '},
                    { 'X', 'O', 'O', 'O', ' ', ' ', ' '},
                };
            Assert.True(puissance.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifVictoireEgaliter()
        {
            PuissanceQuatre puissance = new PuissanceQuatre();
            puissance.grille = new char[4, 7]
            {
                    { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                    { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                    { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                    { 'O', 'X', 'O', 'X', 'O', 'X', 'O'},
                };
            Assert.True(puissance.verifVictoire('X'));
        }
        [Fact]
        public void TestVerifEgalite()
        {
            PuissanceQuatre puissance = new PuissanceQuatre();
            puissance.grille = new char[4, 7]
            {
                    { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                    { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                    { 'X', 'O', 'X', 'O', 'X', 'O', 'X'},
                    { 'O', 'X', 'O', 'X', 'O', 'X', 'O'},
                };
            Assert.True(puissance.verifEgalite());
        }

    }
}
