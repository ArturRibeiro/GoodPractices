namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

internal class ShoppingCart
{
    private List<ProductReadModel> _products;
    private DeliveryInformation _deliveryInformation;
    private PaymentInformation _paymentInformation;

    public IReadOnlyCollection<ProductReadModel> Products => _products.AsReadOnly();
    public DeliveryInformation DeliveryInformation => _deliveryInformation;
    public PaymentInformation PaymentInformation => _paymentInformation;

    public void AddProducts(List<ProductReadModel> products) => _products = products;
    public void AddDeliveryInformation(DeliveryInformation deliveryInformation) => _deliveryInformation = deliveryInformation;
    public void AddPaymentInformation(PaymentInformation paymentInformation) => _paymentInformation = paymentInformation;

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
}