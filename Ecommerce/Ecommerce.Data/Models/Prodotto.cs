using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int QuantitaDisponibile { get; set; }

        // Relazione: ogni prodotto appartiene a una categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Prodotto() { }
        public Prodotto(string nome, string descrizione, decimal prezzo, int quantita, Categoria categoria)
        {
            Nome = nome;
            Descrizione = descrizione;
            Prezzo = prezzo;
            QuantitaDisponibile = quantita;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"{Nome} - {Prezzo:C} ({QuantitaDisponibile} disponibili)";
        }
    }
}
