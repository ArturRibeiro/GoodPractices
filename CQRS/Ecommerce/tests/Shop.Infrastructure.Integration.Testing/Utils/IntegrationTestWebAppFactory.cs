namespace Shop.Infrastructure.Integration.Testing.Utils
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseContentRoot(Directory.GetCurrentDirectory());   
            builder.ConfigureTestServices(services =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options
                        .UseSqlite(@"Data Source=C:\Users\ARRB\OneDrive - GFT Technologies SE\Documents\Projeto\GoodPractices\CQRS\Ecommerce\tests\Shop.Infrastructure.Integration.Testing\Shop.db")
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

        public async new Task DisposeAsync() {}
    }
}