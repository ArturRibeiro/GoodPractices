namespace Shop.Api.Graphs.Mutations.Checkout.Types;

public class ProductInformationGraphType :  InputObjectType<ProductMessageRequest>
{
    protected override void Configure(IInputObjectTypeDescriptor<ProductMessageRequest> descriptor)
    {
        descriptor.Description("Represents the input to Product.");

        descriptor.Field(c => c.Id);
        descriptor.Field(c => c.Quantity);
        
        base.Configure(descriptor);
    }
}