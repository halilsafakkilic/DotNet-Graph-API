using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using netCoreGraphQL.Domains;
using netCoreGraphQL.Models;

namespace netCoreGraphQL.Repositories
{
    public class InMemoryRepository
    {
        private readonly IList<Brand> Brands = new List<Brand>();

        private IList<Product> Products = new List<Product>();

        public InMemoryRepository()
        {
            var dataGenerator = new DataGenerator();

            // Data Seeding
            Brands = dataGenerator.GenerateBrand(5);
            Products = dataGenerator.GenerateProduct(41, Brands);
        }

        public IList<Brand> GetBrands()
        {
            return Brands;
        }

        public Brand AddBrand(Brand brand)
        {
            Brands.Add(brand);

            // Product Seeding
            var dataGenerator = new DataGenerator();
            Products = dataGenerator.GenerateProduct(65, Brands);

            return brand;
        }

        public List<Product> GetProducts(Pagination pagination)
        {
            return Products.Skip(pagination.Skip).Take(pagination.Size).ToList();
        }

        public List<Product> GetProductsByBrandId(Guid brandId, Pagination pagination)
        {
            return Products.Where(p => p.Brand?.Id == brandId).Skip(pagination.Skip).Take(pagination.Size).ToList();
        }
    }
}