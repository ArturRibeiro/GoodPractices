using Writing.Integration.Testing.With.Docker.Integration.Testing.Utils;

namespace Writing.Integration.Testing.With.Docker.Integration.Testing
{
    [Collection("IntegrationTestWebAppFactory")]
    public class ApplicationDbContextTests
    {
        private readonly IntegrationTestWebAppFactory _context;

        public ApplicationDbContextTests(IntegrationTestWebAppFactory context)
        {
            _context = context;
        }

        [Fact]
        public async Task GetApplicationDbContext()
        {
            // using (DbConnection connection = new NpgsqlConnection(_postgreSqlContainer.GetConnectionString()))
            // {
            //     using (DbCommand command = new NpgsqlCommand())
            //     {
            //         connection.Open();
            //         command.Connection = connection;
            //         command.CommandText = "SELECT 1";
            //     }
            // }

            var dbContext = _context.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
    }
}