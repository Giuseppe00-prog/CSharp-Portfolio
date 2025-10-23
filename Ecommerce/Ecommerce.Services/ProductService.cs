using Ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    internal class ProductService
    {
        private readonly ECommerceContext _ecommerceContext;

        public ProductService(ECommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }
        //Aggiunta di un nuovo prodotto
        public void AddProduct(Prodotto p)
        {
            if (p == null) return;

            _ecommerceContext.Prodotti.Add(p);
            _ecommerceContext.SaveChanges();
        }
        //Ritorna tutta la lista di prodotti
        public List<Prodotto> GetAllProdotti()
        {
            return _ecommerceContext.Prodotti.ToList();
        }
        //Rimozione prodotto per id
        public bool RemoveProductById(int id)
        {
            var prodotto = _ecommerceContext.Prodotti.FirstOrDefault(p => p.Id == id);
            if (prodotto == null) return false;
            _ecommerceContext.Prodotti.Remove(prodotto);
            _ecommerceContext.SaveChanges();
            return true;
        }
    }
}
