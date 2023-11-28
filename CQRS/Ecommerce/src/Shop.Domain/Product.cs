namespace Shop.Domain;

public class Product : Entity<long>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public int QuantityInStock { get; private set; }
    
    public Product() { }

    public Product(string name, string description, double price, int quantityInStock)
    {
        Name = name;
        Description = description;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Métodos para manipulação do produto
}