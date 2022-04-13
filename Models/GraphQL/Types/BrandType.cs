using GraphQL.Types;
using netCoreGraphQL.Domains;

namespace netCoreGraphQL.Models.GraphQL.Types;

public class BrandType : ObjectGraphType<Brand>
{
    public BrandType()
    {
        Name = "Brand";

        Field(p => p.Id, type: typeof(IdGraphType));
        Field(p => p.Name);
    }
}