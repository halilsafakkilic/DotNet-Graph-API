using GraphQL.Server.Ui.GraphiQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using netCoreGraphQL.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

Bootstrap.ConfigureServices(builder.Services);

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseGraphQLGraphiQL(new GraphiQLOptions
{
    GraphQLEndPoint = new PathString("/api/v1")
});

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();