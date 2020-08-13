using GraphQL.Types;
using netCoreGraphQL.Repositories;
using netCoreGraphQL.Models.GraphQL.Types;

namespace netCoreGraphQL.Models.GraphQL.Queries
{
    public class BrandQuery : ObjectGraphType<object>
    {
        public BrandQuery(InMemoryRepository repository)
        {
            Name = "Brand_Query";
            Description = "Brand Queries";

            Field<ListGraphType<BrandType>>("find", resolve: ctx => repository.GetBrands());
        }
    }
}