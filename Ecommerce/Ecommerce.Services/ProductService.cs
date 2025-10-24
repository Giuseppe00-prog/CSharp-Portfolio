using Ecommerce.Data.Models;
using Ecommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class ProductService
    {
        private readonly ProdottoRepository _repository;

        public ProductService(ProdottoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Prodotto>> ListaProdotti()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AggiungiProdotto(Prodotto prodotto)
        {
            await _repository.AddAsync(prodotto);
        }
    }
}
