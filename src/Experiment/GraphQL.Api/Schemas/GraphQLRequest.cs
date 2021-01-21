using Newtonsoft.Json.Linq;

namespace GraphQL.Api.Schemas
{
    public class GraphQLRequest
    {
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
