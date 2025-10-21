using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulator.Models
{
    internal class ContoCorrente
    {
        public string NumeroConto {  get; private set; }
        public decimal Saldo { get; private set; }

        public List<Operazione> StoricoOperazioni { get; private set; }

        public ContoCorrente(string numeroConto)
        {
            NumeroConto = numeroConto;
            Saldo = 0;
            StoricoOperazioni = new List<Operazione>();
        }

        public void Deposita(decimal importo)
        {
            if (importo <= 0)
                throw new ArgumentException("L'importo deve essere positivo");
            Saldo += importo;
            StoricoOperazioni.Add(new Operazione("Deposito", importo, DateTime.Now));
        }
        public void Preleva(decimal importo)
        {
            if (importo <= 0)
                throw new ArgumentException("L'importo deve essere positivo");
            if (importo > Saldo)
                throw new InvalidOperationException("Saldo insufficiente");
            Saldo -= importo;
            StoricoOperazioni.Add(new Operazione("Preleva", -importo, DateTime.Now));
        }
        public void Bonifico(ContoCorrente destinatario, decimal importo)
        {
            if (importo <= 0)
                throw new ArgumentException("L'importo deve essere positivo");
            if(importo > Saldo)
                throw new InvalidOperationException("Saldo insufficiente per il bonifico");
            Saldo -= importo;
            destinatario.Saldo += importo;
            StoricoOperazioni.Add(new Operazione("Bonifico", -importo, DateTime.Now));
            destinatario.StoricoOperazioni.Add(new Operazione($"Bonifico da {NumeroConto}", importo, DateTime.Now));
        }
        public override string ToString()
        {
            return $"Conto: {NumeroConto} | Saldo: {Saldo:C}";
        }
    }
}
