using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.Interfaces;

namespace SEDCWebApplication.Models.Implementations
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;
        public MockProductRepository()
        {
            _productList = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "Vegeteriana",
                    UnitPrice = 450,
                    DiscountedPrice = 400,
                    IsDiscounted = false,
                    IsActive = IsActiveEnum.Yes,
                    IsDeleted = IsDeletedEnum.No,
                    Picture = "~/images/Products/vegetariana.jpg",
                    Description = "Pelat, kačkavalj, masline, paprika, sezonsko povrće."
                },

                new Product
                {
                    Id = 2,
                    ProductName = "Capricciosa",
                    UnitPrice = 550,
                    DiscountedPrice = 500,
                    IsDiscounted = true,
                    IsActive = IsActiveEnum.Yes,
                    IsDeleted = IsDeletedEnum.No,
                    Picture = "~/images/Products/capricciosa.jpg",
                    Description = "Pelat, kačkavalj, pečenica, suvi vrat, šampinjoni."
                },

                new Product
                {
                    Id = 3,
                    ProductName = "Quattro Stagioni",
                    UnitPrice = 550,
                    DiscountedPrice = 500,
                    IsDiscounted = true,
                    IsActive = IsActiveEnum.Yes,
                    IsDeleted = IsDeletedEnum.No,
                    Picture = "~/images/Products/quattro_stagioni.jpg",
                    Description = "Pelat, kačkavalj, pečenica, suvi vrat, kulen, pančeta, jaja, masline, pavlaka."
                },

                new Product
                {
                    Id = 4,
                    ProductName = "Quattro Formaggi",
                    UnitPrice = 550,
                    DiscountedPrice = 500,
                    IsDiscounted = false,
                    IsActive = IsActiveEnum.Yes,
                    IsDeleted = IsDeletedEnum.No,
                    Picture = "~/images/Products/quatro_formaggi.jpg",
                    Description = "Pelat, kačkavalj, mocarela, gorgonzola, parmezan, masline."
                },

                new Product
                {
                    Id = 5,
                    ProductName = "Funghi",
                    UnitPrice = 570,
                    DiscountedPrice = 520,
                    IsDiscounted = true,
                    IsActive = IsActiveEnum.Yes,
                    IsDeleted = IsDeletedEnum.No,
                    Picture = "~/images/Products/funghi.jpg",
                    Description = "Pelat, kačkavalj, šampinjoni, mocarela, gorgonzola, masline."
                },

                new Product
                {
                    Id = 6,
                    ProductName = "Calzone",
                    UnitPrice = 650,
                    DiscountedPrice = 600,
                    IsDiscounted = false,
                    IsActive = IsActiveEnum.Yes,
                    IsDeleted = IsDeletedEnum.No,
                    Picture = "~/images/Products/calzone.jpg",
                    Description = "Pelat, pečenica, šampinjoni, kačkavalj, suvi vrat, jaje, masline."
                }
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product GetProductById(int id)
        {
            return _productList.Where(x => x.Id == id).FirstOrDefault();
        }
        public Product Add(Product product)
        {
            product.Id = _productList.Max(p => p.Id) + 1;
            _productList.Add(product);
            return product;
        }
    }
}
