namespace Shop.Api.Graphs.Mutations.Checkout.Types;

public class PaymentInformationGraphType :  InputObjectType<CreditCardMessageRequest>
{
    protected override void Configure(IInputObjectTypeDescriptor<CreditCardMessageRequest> descriptor)
    {
        descriptor.Description("Represents the input to Credit card.");

        descriptor.Field(c => c.Number);
        descriptor.Field(c => c.ExpirationDate);
        descriptor.Field(c => c.CVV);

        base.Configure(descriptor);
    }
}