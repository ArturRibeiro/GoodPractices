namespace Pattern.Options.Unit.Testing.Utils
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private IConfigurationRoot configuration;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    configuration = config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                        .Build();
                })
                .ConfigureTestServices(services =>
                {
                    services
                        .Configure<ApplicationConfiguration>(configuration.GetSection(nameof(ApplicationConfiguration)))
                        .AddSingleton<IValidateOptions<ApplicationConfiguration>, ConfigurationValidateOptions<ApplicationConfiguration>>()
                        .AddOptions<ApplicationConfiguration>()
                        .ValidateDataAnnotations()
                        .ValidateOnStart();
                });
            
            base.ConfigureWebHost(builder);
        }

        public IServiceProvider Provider => this.Services.CreateScope().ServiceProvider; 

        public Task InitializeAsync() => Task.CompletedTask;

        public new Task DisposeAsync() => Task.CompletedTask;
    }
}