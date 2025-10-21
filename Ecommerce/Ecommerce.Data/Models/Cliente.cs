using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Indirizzo { get; set; }

        // Relazione: un cliente può avere più ordini
        //public List<Ordine> Ordini { get; set; } = new List<Ordine>();

        public Cliente(string nome, string cognome, string email, string indirizzo)
        {
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Indirizzo = indirizzo;
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} - {Email}";
        }
    }
    
}
