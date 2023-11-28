namespace Shop.Domain.Orders;

public class Client : User
{
    public Address Address { get; private set; }
    public PaymentInfo Payment { get; private set; }
}