namespace Shop.Domain;

public class Product : Entity<long>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Price Price { get; private set; }
    public int QuantityInStock { get; private set; }
    
    public Product() { }

    public Product(long id, Price price)
    {
        this.Id = id;
        this.Price = price;
    }

    public Product(string name, string description, Price price, int quantityInStock)
    {
        Name = name;
        Description = description;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Métodos para manipulação do produto
}