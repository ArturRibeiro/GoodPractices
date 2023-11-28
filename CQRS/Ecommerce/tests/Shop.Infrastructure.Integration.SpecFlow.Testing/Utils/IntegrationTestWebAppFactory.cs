namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        builder.UseContentRoot(currentDirectory);   
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseSqlite($"Data Source={currentDirectory}\\ShopSpecFlow.db")
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
            });
        });
            
        base.ConfigureWebHost(builder);
    }
    
    public ApplicationDbContext ApplicationDbContext =>
        this.Services
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

    public async Task InitializeAsync() {}

    public async new Task DisposeAsync() { }
}