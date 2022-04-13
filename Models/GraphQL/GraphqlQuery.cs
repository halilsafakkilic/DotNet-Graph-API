using Newtonsoft.Json.Linq;

namespace netCoreGraphQL.Models.GraphQL;

public class GraphqlQuery
{
    public string OperationName { get; set; }

    public string Query { get; set; }

    public JObject Variables { get; set; }
}