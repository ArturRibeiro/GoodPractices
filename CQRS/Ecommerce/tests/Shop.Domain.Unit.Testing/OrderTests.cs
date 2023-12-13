namespace Shop.Domain.Unit.Testing;

public class OrderTests
{
    [Theory]
    [ClassData(typeof(OrderPendingFaker))]
    public void CreateOrderPending(Client client, Order order, PaymentInfo paymentInfo, Item[] items,
        Status status)
    {
        // Arrange's
        client.Should().NotBeNull();
        order.Should().NotBeNull();
        items.Should().NotBeNull();
        items.Should().HaveCount(5);

        // Act
        order.AddItem(client, items);

        // Assert's
        order.Should().BeOfType(order.GetType());
        order.Buyer.Should().NotBeNull();
        order.Buyer.Should().BeOfType(client.GetType());
        order.Items.Should().HaveCount(5);
        order.TotalPrice.Value.Should().BeGreaterThan(0);
        order.Status.Should().Be(status);
        order.Status.Id.Should().Be(status.Id);
        order.Status.Name.Should().Be(status.Name);
    }
        
    [Theory]
    [ClassData(typeof(OrderAwaitingPaymentFaker))]
    public void OrderAwaitingPayment(Order order, PaymentInfo paymentInfo,
        Status status)
    {
        // Arrange's
        order.Should().NotBeNull();
        order.Buyer.Should().NotBeNull();
        order.Items.Should().NotBeNull();
        order.Items.Should().HaveCount(5);

        // Act
        order.Checkout();

        // Assert's
        order.Should().BeOfType(order.GetType());
        order.Buyer.Should().NotBeNull();
        order.Items.Should().HaveCount(5);
        order.TotalPrice.Value.Should().BeGreaterThan(0);
        order.TotalPrice.Value.Should().Be(order.Items.Sum(x => x.Product.Price.Value));
        order.Status.Should().Be(status);
        order.Status.Id.Should().Be(status.Id);
        order.Status.Name.Should().Be(status.Name);
    }
        
    [Theory]
    [ClassData(typeof(OrderAwaitingPaymentFaker))]
    public void OrderAwaitingShipment(Order order, PaymentInfo paymentInfo,
        Status status)
    {
        // Arrange's
        order.Should().NotBeNull();
        order.Buyer.Should().NotBeNull();
        order.Items.Should().NotBeNull();
        order.Items.Should().HaveCount(5);

        // Act
        order.Checkout();

        // Assert's
        order.Should().BeOfType(order.GetType());
        order.Buyer.Should().NotBeNull();
        order.Items.Should().HaveCount(5);
        order.TotalPrice.Value.Should().BeGreaterThan(0);
        order.TotalPrice.Value.Should().Be(order.Items.Sum(x => x.Product.Price.Value));
        order.Status.Should().Be(status);
        order.Status.Id.Should().Be(status.Id);
        order.Status.Name.Should().Be(status.Name);
    }
        
    [Theory]
    [ClassData(typeof(OrderShippedFaker))]
    public void OrderShipped(Order order, PaymentInfo paymentInfo,
        Status status)
    {
        // Arrange's
        order.Should().NotBeNull();
        order.Buyer.Should().NotBeNull();
        order.Items.Should().NotBeNull();
        order.Items.Should().HaveCount(5);

        // Act
        order.ToSend();

        // Assert's
        order.Should().BeOfType(order.GetType());
        order.Buyer.Should().NotBeNull();
        order.Items.Should().HaveCount(5);
        order.TotalPrice.Value.Should().BeGreaterThan(0);
        order.Status.Should().Be(status);
        order.Status.Id.Should().Be(status.Id);
        order.Status.Name.Should().Be(status.Name);
    }
        
    [Theory]
    [ClassData(typeof(OrderCancelledFaker))]
    public void OrderCancelled(Order order, PaymentInfo paymentInfo,
        Status status)
    {
        // Arrange's
        order.Should().NotBeNull();
        order.Buyer.Should().NotBeNull();
        order.Items.Should().NotBeNull();
        order.Items.Should().HaveCount(5);

        // Act
        order.Cancel();

        // Assert's
        order.Should().BeOfType(order.GetType());
        order.Buyer.Should().NotBeNull();
        order.Items.Should().HaveCount(5);
        order.TotalPrice.Value.Should().BeGreaterThan(0);
        order.Status.Should().Be(status);
        order.Status.Id.Should().Be(status.Id);
        order.Status.Name.Should().Be(status.Name);
    }

    [Theory]
    [ClassData(typeof(OrderCompletedFaker))]
    public void OrderCompleted(Order order, PaymentInfo paymentInfo,
        Status status)
    {
        // Arrange's
        order.Should().NotBeNull();
        order.Buyer.Should().NotBeNull();
        order.Items.Should().NotBeNull();
        order.Items.Should().HaveCount(5);
        
        // Act
        order.Conclude();
        
        // Assert's
        order.Should().BeOfType(order.GetType());
        order.Buyer.Should().NotBeNull();
        order.Items.Should().HaveCount(5);
        order.TotalPrice.Value.Should().BeGreaterThan(0);
        order.Status.Should().Be(status);
        order.Status.Id.Should().Be(status.Id);
        order.Status.Name.Should().Be(status.Name);
    }
}