namespace Shop.Api.Graphs.Mutations.Checkout;

public class CheckoutMutationGraphType :  InputObjectType<CheckoutMessageResponse>
{
    protected override void Configure(IInputObjectTypeDescriptor<CheckoutMessageResponse> descriptor)
    {
        descriptor.Description("Represents the input to Checkout.");

        descriptor.Field(c => c.ProductId);

        base.Configure(descriptor);
    }
}

public record CheckoutMessageResponse (long ProductId);