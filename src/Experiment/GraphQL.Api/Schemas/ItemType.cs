using GraphQL.Api.Models;
using GraphQL.Types;

namespace GraphQL.Api.Schemas
{
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Barcode);
            Field(i => i.Title);
            Field(i => i.SellingPrice);
        }
    }
}
