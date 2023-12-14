namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps.Contracts;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int QuantityInStock { get; set; }
}