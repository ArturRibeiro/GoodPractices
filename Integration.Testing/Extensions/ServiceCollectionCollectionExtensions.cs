namespace Integration.Testing.Extensions
{
    public static class ServiceCollectionCollectionExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention();
            });

            return services;
        }
    }
}