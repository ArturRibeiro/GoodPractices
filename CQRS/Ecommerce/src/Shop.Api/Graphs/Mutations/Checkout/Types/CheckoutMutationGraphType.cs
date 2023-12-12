namespace Shop.Api.Graphs.Mutations.Checkout.Types;

public class CheckoutMutationGraphType :  InputObjectType<CheckoutMessageRequest>
{
    protected override void Configure(IInputObjectTypeDescriptor<CheckoutMessageRequest> descriptor)
    {
        descriptor.Description("Represents the input to Checkout.");
        descriptor.Field(c => c.CreditCard).Type<PaymentInformationGraphType>();
        descriptor.Field(c => c.Products).Type<ListType<ProductInformationGraphType>>();
        descriptor.Field(c => c.ShippingAddress).Type<UserShippingAddressInformationGraphType>();

        base.Configure(descriptor);
    }
}