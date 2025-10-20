using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Libro
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public DateOnly Anno { get; set; } 

        public Libro(string titolo, string autore, DateOnly anno)
        {
            Titolo = titolo;
            Autore = autore;
            Anno = anno;
        }
        public void Presentazione()
        {
            Console.WriteLine($"Il titolo del libro è {Titolo}, l'autore è {Autore}, ed è stato pubblicato in data {Anno.Year}");
        }
    }
}
