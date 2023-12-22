using FluentAssertions;

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
        var orders = _factory.ApplicationDbContext.Users.ToList();

        orders.Should().NotBeNull();
    }
}