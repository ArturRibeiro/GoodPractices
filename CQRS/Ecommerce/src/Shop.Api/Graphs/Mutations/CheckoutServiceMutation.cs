namespace Shop.Api.Graphs.Mutations;

[ExtendObjectType("Mutation")]
public record CheckoutServiceMutation
{
    public CheckoutMessageResponse Checkout(
        CheckoutMessageRequest input
        , [Service] ICheckoutApp checkoutApp)
    {
        checkoutApp.Checkout(input);
        
        return new CheckoutMessageResponse(true);
    }
}