using GraphQL.Api.Models;
using GraphQL.Api.Repositories;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQL.Api.Schemas
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IDataStore dataStore)
        {
            Field(o => o.Tag);
            Field(o => o.CreatedAt);
            Field<CustomerType, Customer>()
                .Name("Customer")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetCustomerByIdAsync(ctx.Source.CustomerId);
                });

            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
                .Name("Items")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetOrderItemByOrderIdAsync(ctx.Source.OrderId);
                });
        }
    }
}
