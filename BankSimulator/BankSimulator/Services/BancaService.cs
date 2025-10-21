using BankSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulator.Services
{
    internal class BancaService
    {
        private List<Cliente> _clienti;
        
        public BancaService()
        {
            _clienti = new List<Cliente>();
        }

        public Cliente CreaCliente(string nome, string cognome)
        {
            if (nome == null || cognome == null)
                throw new ArgumentNullException("Inserire un nome e un cognome validi");
            Cliente cliente = new Cliente(nome, cognome);
            _clienti.Add(cliente);
            return cliente;
        }
        public Cliente? TrovaCliente(Guid id)
        {
            return _clienti.FirstOrDefault(x => x.Id == id);
        }
        public ContoCorrente CreaConto(Cliente cliente, string numeroConto)
        {
            ContoCorrente conto = new ContoCorrente(numeroConto);
            cliente.AggiungiConto(conto);
            return conto;
        }
        public void Deposita(ContoCorrente conto, decimal importo)
        {
            conto.Deposita(importo);
        }
        public void Preleva(ContoCorrente conto, decimal importo)
        {
            conto.Preleva(importo);
        }
        public void Bonifico(ContoCorrente mittente, ContoCorrente destinatario, decimal importo)
        {
            mittente.Bonifico(destinatario, importo);
        }
        public void MostraStorico(ContoCorrente conto)
        {
            Console.WriteLine($"Storico operazioni conto {conto.NumeroConto}:");
            foreach (var op in conto.StoricoOperazioni)
            {
                Console.WriteLine(op);
            }
        }
        public void MostraClienti()
        {
            foreach (var c in _clienti)
            {
                Console.WriteLine(c);
                foreach (var conto in c.Conti)
                {
                    Console.WriteLine($"  - {conto}");
                }
            }
        }
    }
}
