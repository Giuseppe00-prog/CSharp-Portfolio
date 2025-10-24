using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ProdottoRepository: Repository<Prodotto>
    {
        public ProdottoRepository(ECommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }
        public async Task<IEnumerable<Prodotto>> GetByCategoriaAsync(int categoriaId)
        {
            return await _dbSet.Include(p => p.Categoria).Where(p=> p.CategoriaId == categoriaId).ToListAsync();
        }
    }
}
