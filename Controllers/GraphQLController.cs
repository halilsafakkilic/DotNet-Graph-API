using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Transport;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace netCoreGraphQL.Controllers;

[Route("api/v1")]
[ApiController]
public class GraphQlController : ControllerBase
{
    private readonly IDocumentExecuter _documentExecuter;
    private readonly ISchema _schema;

    public GraphQlController(IDocumentExecuter documentExecuter, ISchema schema)
    {
        _documentExecuter = documentExecuter;
        _schema = schema;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(new SchemaPrinter(_schema).Print());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public async Task Post(CancellationToken cancellationToken)
    {
        var request = await JsonSerializer.DeserializeAsync<GraphQLRequest>
        (
            HttpContext.Request.Body,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
        );

        try
        {
            var result = await _documentExecuter.ExecuteAsync(x =>
            {
                x.Schema = _schema;
                if (request != null) x.Query = request.Query;
                x.CancellationToken = cancellationToken;
            }).ConfigureAwait(false);
            if (result.Errors?.Count > 0)
            {
                WriteExecutionResultAsync(result, 400, cancellationToken);
                return;
            }

            WriteExecutionResultAsync(result, 200, cancellationToken);
        }
        catch (Exception)
        {
            WriteResponseAsync(
                new GraphQLSerializer().Serialize(new {Error = "Unexpected Exception"}), 500,
                cancellationToken);
        }
    }

    private void WriteExecutionResultAsync(ExecutionResult result, int statusCode,
        CancellationToken cancellationToken)
    {
        var output = new GraphQLSerializer().Serialize(result);

        WriteResponseAsync(output, statusCode, cancellationToken);
    }

    private async void WriteResponseAsync(string output, int statusCode, CancellationToken cancellationToken)
    {
        HttpContext.Response.ContentType = "application/json";
        HttpContext.Response.StatusCode = statusCode;

        await HttpContext.Response.WriteAsync(output, cancellationToken);
    }
}