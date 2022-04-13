using System;
using GraphQL;
using GraphQL.Types;
using netCoreGraphQL.Models.GraphQL.Types;
using netCoreGraphQL.Repositories;

namespace netCoreGraphQL.Models.GraphQL.Queries;

public class ProductQuery : ObjectGraphType<object>
{
    public ProductQuery(InMemoryRepository repository)
    {
        Name = "Product_Query";
        Description = "Product Queries";

        Field<ListGraphType<ProductType>>("find",
            arguments: PaginationType.GetQueryArgumentsForPagination(),
            resolve: ctx => repository.GetProducts(Pagination.CreateInstanceFromQuery(ctx)));


        Field<ListGraphType<ProductType>>("findByBrandId",
            arguments: PaginationType.GetQueryArgumentsForPagination(new QueryArguments
            {
                new QueryArgument<IdGraphType>
                {
                    Name = "Id",
                    Description = "Brand Id"
                }
            }),
            resolve: ctx =>
                repository.GetProductsByBrandId(ctx.GetArgument<Guid>("id"), Pagination.CreateInstanceFromQuery(ctx)));
    }
}