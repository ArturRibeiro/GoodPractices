using Shop.Infrastructure;

namespace Shop.Api;

public class Startup
{
    private readonly WebApplicationBuilder _builder;
    private WebApplication _app;

    public Startup(WebApplicationBuilder builder) => _builder = builder;

    public Startup AddServices()
    {
        _builder.Services.AddControllers();
        _builder.Services.AddEndpointsApiExplorer();

        _builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        _builder.Services.AddScoped<IClientRepository, ClientRepository>();
        _builder.Services.AddScoped<ICheckoutApp, CheckoutApp>();
        _builder.Services.AddScoped<IApplicationUser>(_ => new ApplicationUserMock());
        
        var currentDirectory = Directory.GetCurrentDirectory();
        var dataBase = $"Data Source={currentDirectory}\\Shop.db";
        
        _builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseSqlite(dataBase)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        });
                
        _builder.Services.AddDbContext<ApplicationDbContextReadOnly>(options =>
        {
            options
                .UseSqlite(dataBase)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        });

        return this;
    }

    public Startup AddServiceGraphQL()
    {
        _builder.Services
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<DummyQuery>()
            .AddTypeExtension<ProductQuery>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<CheckoutServiceMutation>()
            .AddType<CheckoutMutationGraphType>()
            .AddType<PaymentInformationGraphType>()
            .AddType<ProductInformationGraphType>()
            .AddType<UserShippingAddressInformationGraphType>()
            .AddType<DummyType>()
            .AddType<ProductType>()
            .AddProjections()
            .AddFiltering()
            .RegisterService<ApplicationUserMock>()
            .RegisterDbContext<ApplicationDbContextReadOnly>();
        return this;
    }

    public Startup AddConfigure()
    {
        var app = _builder.Build();
        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapGraphQL();
        app.UseGraphQLVoyager("/ui/voyager");

        _app = app;

        return this;
    }

    public Startup Run()
    {
        _app.Run();
        return this;
    }
}