using GraphQL.Types;
using netCoreGraphQL.Models.GraphQL.Types;
using netCoreGraphQL.Repositories;

namespace netCoreGraphQL.Models.GraphQL.Queries;

public class BrandQuery : ObjectGraphType<object>
{
    public BrandQuery(InMemoryRepository repository)
    {
        Name = "Brand_Query";
        Description = "Brand Queries";

        Field<ListGraphType<BrandType>>("find", resolve: ctx => repository.GetBrands());
    }
}