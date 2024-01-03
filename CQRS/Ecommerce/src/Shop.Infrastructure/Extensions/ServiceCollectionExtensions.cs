namespace Shop.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IEventSourcingRepository, EventSourcingRepository>();
        services.AddScoped<IApplicationUser>(_ => new ApplicationUser());
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dataBase = $"Data Source={currentDirectory}\\Shop.db";
            options
                .UseSqlite(dataBase)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        });
                

        
        return services;
    }
}