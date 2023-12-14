namespace Shop.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            // cfg.AddBehavior<PingPongBehavior>();
            // cfg.AddStreamBehavior<PingPongStreamBehavior>();
            // cfg.AddRequestPreProcessor<PingPreProcessor>();
            // cfg.AddRequestPostProcessor<PingPongPostProcessor>();
            // cfg.AddOpenBehavior(typeof(GenericBehavior<,>));
        });

        services.AddScoped<MediatorService>();
        services.AddScoped<IServiceClient, ServiceClient>();

        return services;
    }
}