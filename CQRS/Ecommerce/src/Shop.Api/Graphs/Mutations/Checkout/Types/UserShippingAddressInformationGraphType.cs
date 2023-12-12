namespace Shop.Api.Graphs.Mutations.Checkout.Types;

public class UserShippingAddressInformationGraphType :  InputObjectType<UserShippingAddressMessageRequest>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserShippingAddressMessageRequest> descriptor)
    {
        descriptor.Description("Represents the input to User Address.");

        descriptor.Field(c => c.Option);
        
        base.Configure(descriptor);
    }
}