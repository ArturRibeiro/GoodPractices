namespace Integration.Testing.Utils
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("eshop")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.ConfigureDbContext(_dbContainer.GetConnectionString());
            });
            
            base.ConfigureWebHost(builder);
        }

        public string ConnectionString => _dbContainer.GetConnectionString();

        public Task InitializeAsync() => _dbContainer.StartAsync();

        public new Task DisposeAsync() => _dbContainer.StopAsync();
    }
}