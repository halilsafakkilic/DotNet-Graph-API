using System;
using System.Collections.Generic;
using Bogus;
using netCoreGraphQL.Domains;

namespace netCoreGraphQL.Repositories;

public class DataGenerator
{
    private readonly Faker _faker;

    public DataGenerator()
    {
        _faker = new Faker();
    }

    public IList<Brand> GenerateBrand(int limit)
    {
        var Brands = new List<Brand>();

        for (var i = 0; i < limit; i++) Brands.Add(new Brand(Guid.NewGuid(), _faker.Name.LastName()));

        return Brands;
    }

    public IList<Product> GenerateProduct(int limit, IList<Brand> Brands)
    {
        var Products = new List<Product>();

        for (var i = 0; i < limit; i++)
            Products.Add(new Product(Guid.NewGuid(), _faker.PickRandom(Brands), _faker.Commerce.ProductName(),
                _faker.Random.Double(10, 100)));

        return Products;
    }
}