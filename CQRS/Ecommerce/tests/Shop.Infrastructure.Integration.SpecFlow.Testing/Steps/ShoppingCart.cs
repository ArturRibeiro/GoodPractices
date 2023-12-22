namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

internal class ShoppingCart
{
    private List<ProductDto> _products;
    private DeliveryInformation _deliveryInformation;
    private PaymentInformation _paymentInformation;

    public IReadOnlyCollection<ProductDto> Products => _products.AsReadOnly();
    public DeliveryInformation DeliveryInformation => _deliveryInformation;
    public PaymentInformation PaymentInformation => _paymentInformation;

    public void AddProducts(List<ProductDto> products) => _products = products;

    public void AddDeliveryInformation(DeliveryInformation deliveryInformation) =>
        _deliveryInformation = deliveryInformation;

    public void AddPaymentInformation(PaymentInformation paymentInformation) =>
        _paymentInformation = paymentInformation;

    public void CheckOut() =>
        this.CheckOutProducts()
            .CheckOutDeliveryInformation()
            .CheckOutPaymentInformation();

    private ShoppingCart CheckOutProducts()
    {
        this.Products.Should().HaveCountGreaterThan(0);
        return this;
    }

    private ShoppingCart CheckOutDeliveryInformation()
    {
        this.DeliveryInformation.Street.Should().NotBeNull();
        this.DeliveryInformation.City.Should().NotBeNull();
        this.DeliveryInformation.State.Should().NotBeNull();
        this.DeliveryInformation.Country.Should().NotBeNull();
        this.DeliveryInformation.ZipCode.Should().NotBeNull();
        return this;
    }

    private ShoppingCart CheckOutPaymentInformation()
    {
        this.PaymentInformation.CreditCardNumber.Should().NotBeNull();
        this.PaymentInformation.CardValidityData.Should().NotBeNull();
        this.PaymentInformation.CVV.Should().NotBeNull();
        return this;
    }

    public MutationGraphql ToMutationGraphql()
    {
        return MutationGraphql
            .Instance("checkout")
            .AddQuery(ToString(this))
            .AddGraphQLResult("success")
            .Builder();
    }

    private static Func<ShoppingCart, string> ToString = shoppingCart =>
    {
        var serializer = new JsonSerializer();
        var stringWriter = new StringWriter();
        using var writer = new JsonTextWriter(stringWriter);
        writer.QuoteName = false;

        serializer.Serialize(writer, CreateAnonymous(shoppingCart));

        return stringWriter.ToString();
    };

    private static Func<ShoppingCart, object> CreateAnonymous = shoppingCart => new
    {
        shippingAddress = new { option = 1 },
        products = shoppingCart.Products.Select(x => new { id = x.Id, quantity = x.QuantityInStock }).ToArray(),
        creditCard = new
        {
            number = shoppingCart.PaymentInformation.CreditCardNumber,
            expirationDate = shoppingCart.PaymentInformation.CardValidityData,
            cvv = shoppingCart.PaymentInformation.CVV
        }
    };
}