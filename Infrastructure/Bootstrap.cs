using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using netCoreGraphQL.Models.GraphQL.Mutations;
using netCoreGraphQL.Models.GraphQL.Queries;
using netCoreGraphQL.Models.GraphQL.Schemas;
using netCoreGraphQL.Models.GraphQL.Types;
using netCoreGraphQL.Repositories;

namespace netCoreGraphQL.Infrastructure;

public static class Bootstrap
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<InMemoryRepository>();
        services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

        services.AddSingleton<RootMutation>();

        services.AddSingleton<RootQuery>();
        services.AddSingleton<ISchema, RootSchema>();

        services.AddSingleton<ProductType>();
        services.AddSingleton<ProductQuery>();

        services.AddSingleton<BrandType>();
        services.AddSingleton<BrandInputType>();
        services.AddSingleton<BrandQuery>();
    }
}