namespace Shop.Domain.Orders;

public class Item : Entity<long>
{
    public Product Product { get; private set; }
    public long ProductId { get; private set; }
    public int Quantity { get; private set; }
    public long OrderId { get; private set; }

    public Item() { }
    
    public Item(Product product, int quantity)
    {
        ProductId = product.Id;
        Quantity = quantity;
    }

    public double Subtotal => this.Product.Price * this.Quantity;
}