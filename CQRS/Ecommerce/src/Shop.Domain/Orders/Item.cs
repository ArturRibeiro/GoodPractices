namespace Shop.Domain.Orders;

public class Item : Entity<long>
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public long OrderId { get; private set; }

    public Item() { }
    
    public Item(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double CalculateSubtotal()
    {
        // Lógica para calcular o subtotal do item
        return 0.0;
    }
}