using System;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Mvc;
using netCoreGraphQL.Models.GraphQL;

namespace netCoreGraphQL.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
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
        public async Task<IActionResult> Post([FromBody] GraphqlQuery query, CancellationToken cancellationToken)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            try
            {
                var result = await _documentExecuter.ExecuteAsync(x =>
                {
                    x.Schema = _schema;
                    x.Query = query.Query;
                    x.Inputs = query.Variables?.ToInputs();
                    x.CancellationToken = cancellationToken;
                }).ConfigureAwait(false);
                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(new { Data = result.Data });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}