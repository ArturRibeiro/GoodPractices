namespace Shop.Domain.Orders;

public class Item : Entity<long>
{
    public Product Product { get; private set; }
    public long ProductId { get; private set; }
    public int Quantity { get; private set; }
    public UnitPrice UnitPrice { get; private set; }
    public long OrderId { get; private set; }

    public Item() { }
    
    public Item(Product product, int quantity)
    {
        Product = product;
        ProductId = product.Id;
        UnitPrice = product.Price;
        Quantity = quantity;
    }

    public decimal Subtotal => this.Product.Price.Value * this.Quantity;
}