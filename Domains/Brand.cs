using System;

namespace netCoreGraphQL.Domains
{
    public class Brand
    {
        public Brand(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}