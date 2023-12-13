using Shop.Api.Reads;
using Shop.Application.Checkouts;
using Shop.Application.Checkouts.Imp;
using Shop.Infrastructure.Integration.SpecFlow.Testing.Mocks;

namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public class ShopWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var dataBase = $"Data Source={currentDirectory}\\ShopSpecFlow.db";
        builder.UseContentRoot(currentDirectory);
        builder
            .ConfigureAppConfiguration(config => config.AddJsonFile($"{currentDirectory}\\appsettings.specflow.json"))
            .ConfigureTestServices(services =>
            {
                // TODO: Possibilita remover serviços e configurar de acordo com a fronteira ...
                //services.Replace<MyIInterface>(sp => new MyInterface(), ServiceLifetime.Singleton);
                
                // services
                //     .Remove<ApplicationDbContext>()
                //     .Remove<ApplicationDbContextReadOnly>()
                //     .Remove<ServiceClient>()
                //     .Remove<DbConnection>();
                
                // services.AddDbContext<ApplicationDbContext>(options =>
                // {
                //     options
                //         .UseSqlite(dataBase)
                //         .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
                // });
                //
                // services.AddDbContext<ApplicationDbContextReadOnly>(options =>
                // {
                //     options
                //         .UseSqlite(dataBase)
                //         .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
                // });

                services.AddScoped<IServiceClient, ServiceClientMock>();
            });

        base.ConfigureWebHost(builder);
    }

    public ApplicationDbContext ApplicationDbContext =>
        this.Services
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

    public async Task<Result<T>> SendQuery<T>(QueryGraphql query)
        where T : class
    {
        var message = ShopWebApplicationFactoryHelper.CreateHttpRequestMessage(HttpMethod.Post, query.Query);
        using var response = await base.CreateClient().SendAsync(message);
        return response
            .SuccessStatusCode()
            .ReadAsStringAsync<T>(query.Name)
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