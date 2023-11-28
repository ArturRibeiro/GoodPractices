namespace Shop.Domain.Orders;

public class Order : Entity<long>
{
    private readonly List<Item> _items = new();
    
    public ReadOnlyCollection<Item> Items => _items.AsReadOnly();
    public double TotalPrice { get; private set; }
    public Client Buyer { get; private set; }
    public DateTime Registered { get; private set; }

    public Status Status { get; private set; } = Status.Pending;

    public Order() { }
    
    public Order Checkout()
    {
        this.Status = Status.AwaitingPayment;
        TotalPrice = _items.Sum(x => x.Product.Price);
        return this;
    }

    public Order AddItem(Client client, params Item [] items)
    {
        _items.AddRange(items);
        this.Buyer = client;
        return this;
    }
    
    public Order RemoveItem(params Item [] items)
    {
        _items.AddRange(items);
        return this;
    }

    public Order ToSend()
    {
        this.Status = Status.Shipped;
        return this;
    }

    public Order Cancel()
    {
        this.Status = Status.Cancelled;
        return this;
    }

    public Order Conclude()
    {
        this.Status = Status.Completed;
        return this;
    }
}