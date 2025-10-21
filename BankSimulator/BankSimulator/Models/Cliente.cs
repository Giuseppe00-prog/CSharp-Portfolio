using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulator.Models
{
    internal class Cliente
    {
        public string Nome {  get; set; }
        public string Cognome { get; set; }
        public Guid Id { get; private set; }

        public List<ContoCorrente> Conti {  get; private set; }
        public Cliente(string nome, string cognome) 
        {
            Nome = nome;
            Cognome = cognome;
            Id = Guid.NewGuid();
            Conti = new List<ContoCorrente>();
        }
        public void AggiungiConto(ContoCorrente conto)
        {
            Conti.Add(conto);
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} (ID: {Id}) - Conti: {Conti.Count}";
        }
    }
}
