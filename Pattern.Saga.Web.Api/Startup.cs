internal class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        // Rebus
        services.AddRebus(rebus => rebus
            .Routing(r =>
                r.TypeBased().MapAssemblyOf<Startup>("eshop-queue"))
            .Transport(t =>
                t.UseRabbitMq(
                    this.Configuration.GetConnectionString("MessageBroker"),
                    "eshop-queue"))
            .Sagas(s =>
                s.StoreInPostgres(
                    this.Configuration.GetConnectionString("Database"),
                    "sagas",
                    "saga_indexes")));
    }

    public void Configure(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}