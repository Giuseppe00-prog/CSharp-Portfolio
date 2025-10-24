using Ecommerce;
using Ecommerce.Data.Models;
using Ecommerce.Repositories;
using Ecommerce.Services;
using System;

public class Program
{
    static async Task Main(string[] args)
    {
        using(var context = new ECommerceContext())
        {
            // Creiamo repository e servizi
            var clienteRepo = new ClienteRepository(context);
            var ordineRepo = new OrdineRepository(context);
            var prodottoRepo = new Repository<Prodotto>(context);

            var clienteService = new ClienteService(clienteRepo);
            var ordineService = new OrderService(ordineRepo, prodottoRepo);

            // Registra un cliente
            var cliente = await clienteService.RegistraClienteAsync("Guido", "La Barca", "guidolabarca@gmail.com", "Via rossi");

            // Crea un ordine
            var prodotti = new Dictionary<int, int> { { 1, 2 }, { 2, 1 } };
            var ordine = await ordineService.CreaOrdineAsync(cliente, prodotti);

            Console.WriteLine($"Ordine {ordine.Id} creato per {cliente.Nome} con {ordine.OrdineProdotti.Count} prodotti.");

            // Mostra ordini
            var ordini = await ordineService.ListaOrdiniAsync();
            foreach (var o in ordini)
            {
                Console.WriteLine($"Ordine {o.Id} - Cliente: {o.Cliente.Nome} - Prodotti: {o.OrdineProdotti.Count}");
            }
            
        }
    }
}