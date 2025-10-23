using Ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class CustomerService
    {
        private readonly ECommerceContext _context;

        public CustomerService(ECommerceContext context)
        {
            _context = context;
        }

        public void AggiungiCliente(string nome,string cognome, string email, string indirizzo)
        {
            var cliente = new Cliente { Nome = nome, Cognome = cognome, Email = email, Indirizzo = indirizzo};
            _context.Clienti.Add(cliente);
            _context.SaveChanges();
            Console.WriteLine($"Cliente '{nome}' aggiunto con successo.");
        }

        public void MostraClienti()
        {
            var clienti = _context.Clienti.ToList();
            if (!clienti.Any())
            {
                Console.WriteLine("Nessun cliente registrato.");
                return;
            }

            foreach (var c in clienti)
                Console.WriteLine($"[{c.Id}] {c.Nome} - {c.Email}");
        }
    }
}
