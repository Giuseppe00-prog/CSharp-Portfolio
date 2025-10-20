using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Libreria
    {
        private List<Libro> _libri;

        public Libreria(List<Libro> libri)
        {
            _libri = libri;
        }

        public bool AggiungiLibro(Libro libro)
        {
            if (libro == null)
                return false;
            _libri.Add(libro);
            return true;
        }

        public Libro? CercaPerAutore(string autore)
        {
            if (autore == null)
                return null;
            return _libri.FirstOrDefault(x => x.Autore.Equals(autore, StringComparison.OrdinalIgnoreCase));
        }
        public Libro? CercaPerTitolo(string titolo)
        {
            if (titolo == null)
                return null;
            return _libri.FirstOrDefault(x => x.Autore.Equals(titolo, StringComparison.OrdinalIgnoreCase));
        }
        public void StampaTutti()
        {
            foreach (Libro libro in _libri)
            {
                libro.Presentazione();
            }
        }
        public void SalvaSuFile(string path)
        {
            if (path == null)
                return ;
            string jsonLibri = JsonSerializer.Serialize(_libri);
            File.WriteAllText(path, jsonLibri);
            return;
        }
        public void CaricaDaFile(string path)
        {
            if (!File.Exists(path))
                return;
            string json = File.ReadAllText(path);
            var libriDaFile = JsonSerializer.Deserialize<List<Libro>>(json);
            if (libriDaFile == null) return;
            _libri = libriDaFile;
            return;

        }
    }
}
