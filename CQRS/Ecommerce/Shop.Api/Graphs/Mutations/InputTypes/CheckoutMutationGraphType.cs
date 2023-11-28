namespace Shop.Api.Graphs.Mutations.InputTypes;

public class CheckoutMutationGraphType :  InputObjectType<CheckoutMessageResponse>
{
    protected override void Configure(IInputObjectTypeDescriptor<CheckoutMessageResponse> descriptor)
    {
        descriptor.Description("Represents the input to Checkout.");

        descriptor.Field(c => c.ProductId);

        base.Configure(descriptor);
    }
}

public class CheckoutMessageResponse
{
    public long ProductId { get; set; }
}