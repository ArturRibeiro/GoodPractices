namespace Shop.Domain.Unit.Testing.Fakes;

public class OrderPendingFaker : TheoryData<Client, Order, PaymentInfo, Item [], Status>
{
    public OrderPendingFaker()
    {
        var order = Builder<Order>.CreateNew()
            .With(x=>x.TotalPrice, 5)
            .Build();
        var client = Builder<Client>.CreateNew().Build();
        
        var product = new Faker<Product>()
            .RuleFor(p => p.Name, p => p.Commerce.Product())
            .RuleFor(p => p.Price, p => decimal.Parse(p.Commerce.Price()))
            .RuleFor(p => p.QuantityInStock, p => p.Random.Int(1, 10))
            .Generate();
        
        var paymentInfo = new PaymentInfo(cardNumber: "3758900531667797", expirationDate: DateTime.Now.AddYears(5), cvv: "145");
        
        var item = Builder<Item>
            .CreateListOfSize(5)
            .All()
            .With(x => x.Product, product)
            .Build()
            .ToArray();
        
        AddRow(client, order, paymentInfo, item, Status.Pending);
    }
}