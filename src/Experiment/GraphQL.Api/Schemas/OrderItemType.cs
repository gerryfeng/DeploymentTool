using GraphQL.Api.Models;
using GraphQL.Api.Repositories;
using GraphQL.Types;

namespace GraphQL.Api.Schemas
{
    public class OrderItemType : ObjectGraphType<OrderItem>
    {
        public OrderItemType(IDataStore dateStore)
        {
            Field(i => i.Id);

            Field<ItemType, Item>().Name("Item").Resolve(ctx =>
            {
                return dateStore.GetItemByBarcode(ctx.Source.Barcode);
            });

            Field(i => i.Quantity);

            Field(i => i.OrderId);

            Field<OrderType, Order>().Name("Order").ResolveAsync(ctx =>
            {
                return dateStore.GetOrderByIdAsync(ctx.Source.OrderId);
            });

        }
    }
}
