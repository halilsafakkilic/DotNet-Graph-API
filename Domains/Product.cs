using System;

namespace netCoreGraphQL.Domains
{
    public class Product
    {
        public Product(Guid id, Brand brand, string name, double price)
        {
            this.Id = id;
            this.Brand = brand;
            this.Name = name;
            this.Price = price;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Brand Brand { get; private set; }
    }
}