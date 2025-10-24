using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(ECommerceContext ecommerceContext) : base(ecommerceContext)
        {
            
        }
        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
