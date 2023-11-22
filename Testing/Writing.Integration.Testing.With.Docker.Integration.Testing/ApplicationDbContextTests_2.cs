using Writing.Integration.Testing.With.Docker.Integration.Testing.Utils;

namespace Writing.Integration.Testing.With.Docker.Integration.Testing
{
    [Collection("IntegrationTestWebAppFactory")]
    public class ApplicationDbContextTests2
    {
        private readonly IntegrationTestWebAppFactory _context;
        
        public ApplicationDbContextTests2(IntegrationTestWebAppFactory context)
        {
            _context = context;
        }

        [Theory(Skip = "Need docker")]
        [InlineData(1)]
        public async Task ExecuteCommand(int esperado)
        {
            int result;
            await using DbCommand command = new NpgsqlCommand();
            command.Connection = new NpgsqlConnection(_context.ConnectionString);
            command.Connection.Open();
            command.CommandText = "SELECT 1";
            result = (int)command.ExecuteScalar();
            command.Connection.Close();
            
            //Assert
            result.Should().Be(esperado);
        }
    }
}