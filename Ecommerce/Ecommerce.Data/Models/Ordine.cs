using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Models
{
    public class Ordine
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataOrdine { get; set; } = DateTime.Now;
        public Decimal Totale { get; set; }

        public Cliente Cliente { get; set; }
        public List<OrdineProdotto> OrdineProdotti { get; set; } = new List<OrdineProdotto>();

        public Ordine() { }
    }
}
