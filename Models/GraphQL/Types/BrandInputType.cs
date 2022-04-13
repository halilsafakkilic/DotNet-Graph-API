using GraphQL.Types;

namespace netCoreGraphQL.Models.GraphQL.Types;

public class BrandInputType : InputObjectGraphType
{
    public BrandInputType()
    {
        Name = "BrandInput";

        Field<NonNullGraphType<StringGraphType>>("name");
    }
}