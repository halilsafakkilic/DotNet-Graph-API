using GraphQL.Types;

namespace netCoreGraphQL.Models.GraphQL.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Name = "RootQuery";
            Field<ProductQuery>("products", resolve: context => new { });
            Field<BrandQuery>("brands", resolve: context => new { });
        }
    }
}