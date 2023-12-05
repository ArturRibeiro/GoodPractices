using Shop.Api.Graphs.Queries.Products;

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
            
            .AddType<DummyType>()
            .AddType<ProductType>()
            
            .AddProjections()
            .AddFiltering()
            //.RegisterDbContext<ApplicationDbContext>()
            ;
        return this;
    }

    public Startup AddConfigure()
    {
        var app = _builder.Build();
        if (app.Environment.IsDevelopment()) { }
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