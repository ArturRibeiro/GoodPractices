namespace Shop.Api.Graphs.Mutations;

[ExtendObjectType("Mutation")]
public class CheckoutServiceMutation
{
    public CheckoutMessageResponse Checkout(
        CheckoutMessageResponse input /*,
        [Service] ApplicationDbContext context*/)
    {
        return new CheckoutMessageResponse(input.ProductId);
    }
}