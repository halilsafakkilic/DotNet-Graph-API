using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using netCoreGraphQL.Repositories;
using netCoreGraphQL.Models.GraphQL.Mutations;
using netCoreGraphQL.Models.GraphQL.Queries;
using netCoreGraphQL.Models.GraphQL.Schemas;
using netCoreGraphQL.Models.GraphQL.Types;

namespace netCoreGraphQL.Infrastructure
{
    public static class Bootstrap
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<InMemoryRepository>();
            services.AddSingleton<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
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
}