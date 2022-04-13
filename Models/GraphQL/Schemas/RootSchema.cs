using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using netCoreGraphQL.Models.GraphQL.Mutations;
using netCoreGraphQL.Models.GraphQL.Queries;

namespace netCoreGraphQL.Models.GraphQL.Schemas;

public class RootSchema : Schema
{
    public RootSchema(IServiceProvider resolver) : base(resolver)
    {
        Query = resolver.GetRequiredService<RootQuery>();
        Mutation = resolver.GetRequiredService<RootMutation>();
    }
}