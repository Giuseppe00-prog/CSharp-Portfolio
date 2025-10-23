using Ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public static class DbSeeder
    {
        public static void Seed(ECommerceContext context)
        {
            // Se ci sono già prodotti non si ripete il seed
            if (context.Prodotti.Any()) return;

            List<Categoria> categorie = new List<Categoria>()
            {
                new Categoria { Nome = "Elettronica" },
                new Categoria { Nome = "Libri" },
                new Categoria { Nome = "Casa" }
            };

            context.Categorie.AddRange(categorie);
            context.SaveChanges();

            List<Prodotto> prodotti = new List<Prodotto>()
            {
                new Prodotto { Nome = "Laptop", Descrizione = "Notebook 16GB RAM", Prezzo = 1200, CategoriaId = categorie[0].Id },
                new Prodotto { Nome = "Romanzo storico", Descrizione = "Avventura nel medioevo", Prezzo = 15, CategoriaId = categorie[1].Id },
                new Prodotto { Nome = "Lampada LED", Descrizione = "Luce bianca da tavolo", Prezzo = 30, CategoriaId = categorie[2].Id  }
            };
            context.Prodotti.AddRange(prodotti);
            context.SaveChanges();
        }
    }
}
