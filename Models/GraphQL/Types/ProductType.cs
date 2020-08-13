using GraphQL.Types;
using netCoreGraphQL.Domains;

namespace netCoreGraphQL.Models.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";

            Field(p => p.Id, type: typeof(IdGraphType));
            Field(p => p.Name);
            Field(p => p.Price);
            Field<BrandType>("Brand", resolve: _ => _.Source.Brand);
        }
    }
}