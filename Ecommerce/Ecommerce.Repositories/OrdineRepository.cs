using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class OrdineRepository : Repository<Ordine>
    {
        public OrdineRepository(ECommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }
        public async Task<IEnumerable<Ordine>> GetOrdiniConDettagliAsync()
        {
            return await _dbSet.Include(o => o.Cliente).Include(o => o.OrdineProdotti).ThenInclude(op => op.Prodotto).ToListAsync();
        }
    }
}
