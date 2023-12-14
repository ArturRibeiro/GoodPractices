using Shop.Api.Reads;
using Shop.Application.Extensions;
using Shop.Infrastructure;
using Shop.Infrastructure.Extensions;
using Shop.Infrastructure.Reads;
using Shop.Infrastructure.Seed;

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
        _builder.Services.AddApplicationModule();
        _builder.Services.AddInfrastructureModule();
        
        _builder.Services.AddDbContext<ApplicationDbContextReadOnly>(options =>
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dataBase = $"Data Source={currentDirectory}\\Shop.db";
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
            .RegisterService<IApplicationUser>()
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
        _app.Seed();
        _app.Run();
        return this;
    }
}