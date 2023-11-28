namespace Shop.Infrastructure.Integration.Testing;

[Collection("IntegrationTestWebAppFactory")]
public class ApplicationDbContextTests
{
    private readonly IntegrationTestWebAppFactory _factory;

    public ApplicationDbContextTests(IntegrationTestWebAppFactory context)
    {
        _factory = context;
    }
    
    [Fact]
    public void Test1()
    {
        var ordres = _factory.ApplicationDbContext.Users.ToList();
    }
}