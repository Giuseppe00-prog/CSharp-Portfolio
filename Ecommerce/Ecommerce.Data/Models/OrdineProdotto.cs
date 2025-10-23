using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Models
{
    public class OrdineProdotto
    {
        public int OrdineId { get; set; }
        public int ProdottoId { get; set; }
        public int Quantita { get; set; }
        public decimal PrezzoUnitario { get; set; }

        public Ordine Ordine { get; set; }
        public Prodotto Prodotto { get; set; }

        public OrdineProdotto(){ }
    }
}
