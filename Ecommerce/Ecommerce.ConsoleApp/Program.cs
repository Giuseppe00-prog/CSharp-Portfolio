using Ecommerce;
using Ecommerce.Data.Models;
using Ecommerce.Services;
using System;
public class Program
{
    static void Main(string[] args)
    {
        using(var context = new ECommerceContext())
        {
            DbSeeder.Seed(context);
            var customerService = new CustomerService(context);
            var orderService = new OrderService(context);

            customerService.AggiungiCliente("Mario", "Rossi", "mario@rossi.it", "Via rossi");
            customerService.MostraClienti();

            // Esempio di ordine: cliente 1 compra 2 prodotti (ID 1 e 2)
            orderService.CreaOrdine(1, new Dictionary<int, int> { { 1, 2 }, { 2, 1 } });
            orderService.MostraOrdini();
        }
    }
}