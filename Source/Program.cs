using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4 ou [Echap] pour quitter.");

                ConsoleKey key;
                do
                {
                    key = Console.ReadKey(true).Key;
                } while (key != ConsoleKey.X && key != ConsoleKey.P && key != ConsoleKey.Escape);

                switch (key)
                {
                    case ConsoleKey.X:
                        Morpion morpion = new Morpion();
                        morpion.GameLoop();
                        break;
                    case ConsoleKey.P:
                        Power4 puissanceQuatre = new Power4();
                        puissanceQuatre.GameLoop();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}


