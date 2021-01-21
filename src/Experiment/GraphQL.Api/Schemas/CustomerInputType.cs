using GraphQL.Types;

namespace GraphQL.Api.Schemas
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType()
        {
            Name = "CustomerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("billingAddress");
        }
    }
}
