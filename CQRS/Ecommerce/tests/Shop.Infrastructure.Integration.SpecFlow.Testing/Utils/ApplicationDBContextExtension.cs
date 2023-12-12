namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public static class ApplicationDBContextExtension
{
    public static void Seed(this ApplicationDbContext @this)
    {
        @this.Clients.AddClients();
        @this.Products.AddProducts();
        (@this.SaveChanges() > 0).Should().BeTrue();
    }
   
    private static void AddProducts(this DbSet<Product> @this)
    {
        var products = new Faker<Product>()
            .RuleFor(p => p.Id, f => 0)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, p => double.Parse(p.Commerce.Price(100, 1000, 2, null)))
            .RuleFor(p => p.QuantityInStock, f => f.Random.Number(1, 100))
            .Generate(30);
        
        @this.AddRange(products);
    }
    
    private static void AddClients(this DbSet<Client> @this)
    {
        var products = new Faker<Client>()
            .RuleFor(p => p.Id, f => 0)
            .RuleFor(p => p.Name, f => f.Person.FullName)
            .RuleFor(p => p.Email, f => f.Internet.Email())
            .RuleFor(p => p.Address, f => new Address(street: "XX", city: "XX", state: "XX", country: "XX", zipcode: "0000"))
            .Generate();
        
        @this.AddRange(products);
    }
}