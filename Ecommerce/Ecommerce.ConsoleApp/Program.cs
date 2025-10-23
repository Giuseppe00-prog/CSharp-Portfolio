using System;
using Ecommerce;
using Ecommerce.Data.Models;
public class Program
{
    static void Main(string[] args)
    {
        using(var context = new ECommerceContext())
        {
            DbSeeder.Seed(context);
            Console.WriteLine("Database popolato con dati di esempio");
            var prodotti =
                context.Prodotti
                .Select(p => new
                {
                    p.Nome,
                    p.Descrizione,
                    p.Prezzo,
                    Categoria = p.Categoria.Nome,
                }).ToList();
            Console.WriteLine("Prodotti disponibili nel database:");
            foreach (var p in prodotti)
            {
                Console.WriteLine($"- {p.Nome} ({p.Categoria}): {p.Prezzo}€ — {p.Descrizione}");
            }
        }
    }
}