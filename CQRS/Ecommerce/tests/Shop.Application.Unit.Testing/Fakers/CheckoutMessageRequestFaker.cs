namespace Shop.Application.Unit.Testing.Fakers;

public class CheckoutMessageRequestFaker : TheoryData<CheckoutMessageRequest, Client>
{
    public CheckoutMessageRequestFaker()
    {
        var products = new ProductMessageRequest(1, 2);
        var creditCard = new CreditCardMessageRequest("23423423", "012023", "748");
        var shippingAddress = new UserShippingAddressMessageRequest(1);

        var request = new CheckoutMessageRequest(new[] { products }, creditCard, shippingAddress);
        var client = Builder<Client>.CreateNew().Build();
        
        Add(request, client);
    }
}