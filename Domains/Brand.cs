using System;

namespace netCoreGraphQL.Domains;

public class Brand
{
    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }
}