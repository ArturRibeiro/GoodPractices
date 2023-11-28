using Shop.Domain;

namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Hooks;

[Binding]
public class Hooks
{
    [BeforeTestRun]
    public static void RegisterPages()
    {
        IntegrationTestWebAppFactory _factory = new IntegrationTestWebAppFactory();
        var context =  _factory.Server.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        context.Users.Add(new User("Artur", "arturrj@gmail.com"));
        context.SaveChanges();
    }
}