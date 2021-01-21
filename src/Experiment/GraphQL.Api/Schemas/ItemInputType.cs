using GraphQL.Types;

namespace GraphQL.Api.Schemas
{
    public class ItemInputType : InputObjectGraphType
    {
        public ItemInputType()
        {
            Name = "ItemInput";
            Field<NonNullGraphType<StringGraphType>>("barcode");
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<DecimalGraphType>>("sellingPrice");
        }
    }
}
