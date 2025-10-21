using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Models
{

    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relazione: una categoria può avere più prodotti
        public List<Prodotto> Prodotti { get; set; } = new List<Prodotto>();

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
    

}
