using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;


namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public class ShopWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
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

    public async Task<Result<T>> SendQuery<T>(Dictionary<string, string> di)
        where T : class
    {
        var queryObject = new
        {
            query = "query { " + di.Keys.First() + " { " + di.Values.First() + " }}"
            //, variables = new { where = new { userId = userId } }//you can add your where cluase here.
        };

        var jsonString = JsonConvert.SerializeObject(queryObject);
        var message = ShopWebApplicationFactoryHelper.CreateHttpRequestMessage(HttpMethod.Post, jsonString);
        using var response = await base.CreateClient().SendAsync(message);
        return response
            .SuccessStatusCode()
            .ReadAsStringAsync<T>(di.Keys.First())
            .ParseGraphQlResultToJson<T>()
            .SetResult();
    }
    
    public async Task<Result<T>> ExceuteMutationAsyn<T>(MutationGraphql mutationGraphql)
        where T : class
    {
        var message = ShopWebApplicationFactoryHelper.CreateHttpRequestMessage(HttpMethod.Post, mutationGraphql.Query);
        using var response = await base.CreateClient().SendAsync(message);
        return response
            .SuccessStatusCode()
            .ReadAsStringAsync<T>(mutationGraphql.Name)
            .ParseGraphQlResultToJson<T>()
            .SetResult();
    }

    public async Task InitializeAsync()
    {
    }

    public async new Task DisposeAsync()
    {
    }
}