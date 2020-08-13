using System;
using GraphQL.Types;
using netCoreGraphQL.Repositories;
using netCoreGraphQL.Domains;
using netCoreGraphQL.Models.GraphQL.Types;

namespace netCoreGraphQL.Models.GraphQL.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(InMemoryRepository repository)
        {
            Field<BrandType>("createBrand",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<BrandInputType>> { Name = "brand" }
              ),
              resolve: context =>
              {
                  var brandInput = context.GetArgument<BrandInputType>("brand");

                  var brand = new Brand(Guid.NewGuid(), brandInput.Name);

                  return repository.AddBrand(brand);
              });
        }
    }
}