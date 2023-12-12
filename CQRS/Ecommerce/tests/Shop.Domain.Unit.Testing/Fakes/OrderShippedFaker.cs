using Shop.Domain.Clients;

namespace Shop.Domain.Unit.Testing.Fakes;

public class OrderShippedFaker : TheoryData<Order, PaymentInfo, Status>
{
    public OrderShippedFaker()
    {
        var order = Builder<Order>.CreateNew().Build();
        var client = Builder<Client>.CreateNew().Build();

        var product = new Faker<Product>()
            .RuleFor(p => p.Name, p => p.Commerce.Product())
            .RuleFor(p => p.Price, p => double.Parse(p.Commerce.Price()))
            .RuleFor(p => p.QuantityInStock, p => p.Random.Int(1, 10))
            .Generate();

        var paymentInfo = new PaymentInfo(cardNumber: "3758900531667797", expirationDate: DateTime.Now.AddYears(5),
            cvv: "145");

        var items = Builder<Item>
            .CreateListOfSize(5)
            .All()
            .With(x => x.Product, product)
            .Build()
            .ToArray();

        order.AddItem(client, items);

        AddRow(order, paymentInfo, Status.Shipped);
    }
}

public class OrderCancelledFaker : TheoryData<Order, PaymentInfo, Status>
{
    public OrderCancelledFaker()
    {
        var order = Builder<Order>.CreateNew().Build();
        var client = Builder<Client>.CreateNew().Build();

        var product = new Faker<Product>()
            .RuleFor(p => p.Name, p => p.Commerce.Product())
            .RuleFor(p => p.Price, p => double.Parse(p.Commerce.Price()))
            .RuleFor(p => p.QuantityInStock, p => p.Random.Int(1, 10))
            .Generate();

        var paymentInfo = new PaymentInfo(cardNumber: "3758900531667797", expirationDate: DateTime.Now.AddYears(5),
            cvv: "145");

        var items = Builder<Item>
            .CreateListOfSize(5)
            .All()
            .With(x => x.Product, product)
            .Build()
            .ToArray();

        order.AddItem(client, items);

        AddRow(order, paymentInfo, Status.Cancelled);
    }
}