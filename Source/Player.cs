using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Player(string name, char symbole)
    {
        public string Name { get; } = name;
        public char Symbole { get; set; } = symbole;
    }
}
