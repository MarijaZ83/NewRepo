using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.Interfaces;

namespace SEDCWebApplication.Models.Implementations
{
    public class DatabaseProductRepository : IProductRepository
    {
        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
