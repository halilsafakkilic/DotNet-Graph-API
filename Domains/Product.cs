using System;

namespace netCoreGraphQL.Domains;

public class Product
{
    public Product(Guid id, Brand brand, string name, double price)
    {
        Id = id;
        Brand = brand;
        Name = name;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; }
    public double Price { get; }
    public Brand Brand { get; }
}