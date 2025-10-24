using Ecommerce.Data.Models;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Interfaces;
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
        private readonly OrdineRepository _ordineRepo;
        private readonly IRepository<Prodotto> _prodottoRepo;

        public OrderService(OrdineRepository ordineRepo, IRepository<Prodotto> prodottoRepo)
        {
            _ordineRepo = ordineRepo;
            _prodottoRepo = prodottoRepo;
        }

        public async Task<Ordine> CreaOrdineAsync(Cliente cliente, Dictionary<int, int> prodottiQuantita)
        {
            if (prodottiQuantita == null || prodottiQuantita.Count == 0)
                throw new ArgumentException("Nessun prodotto selezionato");

            var ordine = new Ordine { ClienteId = cliente.Id, DataOrdine = DateTime.Now };
            ordine.OrdineProdotti = new List<OrdineProdotto>();

            foreach (var kvp in prodottiQuantita)
            {
                var prodotto = await _prodottoRepo.GetByIdAsync(kvp.Key);
                if (prodotto == null) continue;

                ordine.OrdineProdotti.Add(new OrdineProdotto
                {
                    ProdottoId = prodotto.Id,
                    Quantita = kvp.Value
                });
            }

            await _ordineRepo.AddAsync(ordine);

            return ordine;
        }

        public async Task<IEnumerable<Ordine>> ListaOrdiniAsync()
        {
            return await _ordineRepo.GetOrdiniConDettagliAsync();
        }
    }
}
