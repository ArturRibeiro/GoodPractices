using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            })
            .ConfigureTestServices(services =>
            {
                // TODO: Possibilita remover serviços e configurar de acordo com a fronteira ...
                //services.Replace<MyIInterface>(sp => new MyInterface(), ServiceLifetime.Singleton);
            });

        base.ConfigureWebHost(builder);
    }

    public ApplicationDbContext ApplicationDbContext =>
        this.Services
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

    public async Task<Result<T>> Send<T>(string query)
        where T : class
    {
        var queryObject = new
        {
            query
            //, variables = new { where = new { userId = userId } }//you can add your where cluase here.
        };

        var jsonString = JsonConvert.SerializeObject(queryObject);
        using var response = await base.CreateClient().SendAsync(IntegrationTestWebAppFactoryHelper.CreateHttpRequestMessage(HttpMethod.Post, jsonString));
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var obj = JObject.Parse(responseString);
        var result = JsonConvert.DeserializeObject<Result<T>>(obj["data"].ToString(), JsonSerializerSettingsHelper<T>.JsonSettings);
        return result;
    }



    public async Task InitializeAsync()
    {
    }

    public async new Task DisposeAsync()
    {
    }
}