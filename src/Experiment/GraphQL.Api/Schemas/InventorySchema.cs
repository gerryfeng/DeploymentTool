using GraphQL.Types;

namespace GraphQL.Api.Schemas
{
    public class InventorySchema : Schema
    {
        public InventorySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<InventoryQuery>();
            Mutation = resolver.Resolve<InventoryMutation>();
        }
    }
}
