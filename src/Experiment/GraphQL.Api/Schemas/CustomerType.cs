using GraphQL.Api.Models;
using GraphQL.Api.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQL.Api.Schemas
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IDataStore dataStore)
        {
            Field(c => c.Name);
            Field(c => c.BillingAddress);
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetOrdersByCustomerIdAsync(ctx.Source.CustomerId);
                });
        }
    }
}
