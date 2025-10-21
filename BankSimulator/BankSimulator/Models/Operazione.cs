using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulator.Models
{
    internal class Operazione
    {
        public string Tipo {  get; set; }
        public decimal Importo { get; set; }

        public DateTime Data {  get; set; }

        public Operazione(string tipo, decimal importo, DateTime data)
        {
            Tipo = tipo;
            Importo = importo;
            Data = data;
        }

        public override string ToString()
        {
            return $"{Data:g} - {Tipo}: {Importo:C}";
        }
    }
}
