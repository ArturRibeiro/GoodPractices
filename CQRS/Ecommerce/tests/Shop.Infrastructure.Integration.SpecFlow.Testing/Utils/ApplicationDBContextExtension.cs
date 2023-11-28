namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public static class ApplicationDBContextExtension
{
    public static void Seed(this ApplicationDbContext @this)
    {
        @this.Users.AddUsers();
        @this.SaveChanges();
    }

    private static void AddUsers(this DbSet<User> @this)
    {
        var users = new User("Artur Ribeiro",  "arturrj@dominio.com");
        @this.Add(users);
    }
}