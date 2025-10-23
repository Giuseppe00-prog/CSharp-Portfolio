using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class OrderService
    {
        private readonly ECommerceContext _context;

        public OrderService(ECommerceContext context)
        {
            _context = context;
        }

        public void CreaOrdine(int clienteId, Dictionary<int, int> prodottiQuantita)
        {
            var cliente = _context.Clienti.Find(clienteId);
            if (cliente == null)
            {
                Console.WriteLine("Cliente non trovato.");
                return;
            }

            var ordine = new Ordine { ClienteId = clienteId };
            decimal totale = 0;

            foreach (var kvp in prodottiQuantita)
            {
                var prodotto = _context.Prodotti.Find(kvp.Key);
                if (prodotto == null)
                    continue;

                var op = new OrdineProdotto
                {
                    ProdottoId = prodotto.Id,
                    Quantita = kvp.Value,
                    PrezzoUnitario = prodotto.Prezzo
                };

                totale += prodotto.Prezzo * kvp.Value;
                ordine.OrdineProdotti.Add(op);
            }

            ordine.Totale = totale;
            _context.Ordini.Add(ordine);
            _context.SaveChanges();

            Console.WriteLine($"🛒 Ordine creato con successo per {cliente.Nome}, totale: {totale:C2}");
        }

        public void MostraOrdini()
        {
            var ordini = _context.Ordini
                .Include(o => o.Cliente)
                .Include(o => o.OrdineProdotti)
                .ThenInclude(op => op.Prodotto)
                .ToList();

            foreach (var o in ordini)
            {
                Console.WriteLine($"Ordine {o.Id} - Cliente: {o.Cliente.Nome} - Totale: {o.Totale:C2}");
                foreach (var op in o.OrdineProdotti)
                    Console.WriteLine($"   • {op.Prodotto.Nome} x{op.Quantita} ({op.PrezzoUnitario:C2})");
            }
        }
    }
}
