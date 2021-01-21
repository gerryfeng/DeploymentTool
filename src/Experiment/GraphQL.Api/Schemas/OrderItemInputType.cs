using GraphQL.Types;

namespace GraphQL.Api.Schemas
{
    public class OrderItemInputType : InputObjectGraphType
    {
        public OrderItemInputType()
        {
            Name = "OrderItemInput";
            Field<NonNullGraphType<IntGraphType>>("quantity");
            Field<NonNullGraphType<StringGraphType>>("barcode");
            Field<NonNullGraphType<IntGraphType>>("orderId");
        }
    }
}
