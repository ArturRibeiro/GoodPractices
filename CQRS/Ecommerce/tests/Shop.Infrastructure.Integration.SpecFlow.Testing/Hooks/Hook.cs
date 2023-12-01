namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Hooks;

[Binding]
public class Hooks
{
    [BeforeTestRun]
    public static void RegisterPages()
    {
        ShopWebApplicationFactory _factory = new ShopWebApplicationFactory();
        var context =  _factory.Server.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        context.Seed();
    }
}