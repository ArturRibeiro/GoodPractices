namespace Integration.Testing
{
    [Collection("IntegrationTestWebAppFactory")]
    public class ApplicationDbContextTests2
    {
        private readonly IntegrationTestWebAppFactory _context;
        
        public ApplicationDbContextTests2(IntegrationTestWebAppFactory context)
        {
            _context = context;
        }

        [Theory]
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