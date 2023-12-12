
namespace Shop.Domain.Orders;

public class Order : Entity<long>
{
    private readonly List<Item> _items = new();

    public IEnumerable<Item> Items => _items.AsReadOnly();
    public double TotalPrice { get; private set; }
    public Client Buyer { get; private set; }
    public long BuyerId { get; private set; }
    public DateTime Registered { get; private set; } = DateTime.Now;

    public Status Status { get; private set; } = Status.Pending;

    public Order()
    {
    }

    public Order Checkout()
    {
        this.Status = Status.AwaitingPayment;
        TotalPrice = 0;//_items.Sum(x => x.Product.Price);
        return this;
    }

    public Order AddItem(Client client, params Item[] items)
    {
        _items.AddRange(items);
        this.Buyer = client;
        return this;
    }

    public Order AddClient(Client client )
    {
        this.BuyerId = client.Id;
        return this;
    }
    
    public Order AddItem(Func<IEnumerable<Item>> fItems )
    {
        _items.AddRange(fItems());
        return this;
    }

    public Order RemoveItem(params Item[] items)
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

    public record Factory
    {
        public static Order Create() => new();
    }
}