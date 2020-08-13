using GraphQL;
using GraphQL.Types;
using netCoreGraphQL.Models.GraphQL.Mutations;
using netCoreGraphQL.Models.GraphQL.Queries;

namespace netCoreGraphQL.Models.GraphQL.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
            Mutation = resolver.Resolve<RootMutation>();
        }
    }
}