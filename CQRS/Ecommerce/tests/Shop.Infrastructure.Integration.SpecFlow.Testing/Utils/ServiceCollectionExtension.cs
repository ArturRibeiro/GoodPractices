namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public static class ServiceCollectionExtension
{
    public static IServiceCollection Replace<TService>(
        this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory,
        ServiceLifetime lifetime)
        where TService : class
    {
        var descriptorToRemove = services.FirstOrDefault(d => d.ServiceType == typeof(TService));

        services.Remove(descriptorToRemove);

        var descriptorToAdd = new ServiceDescriptor(typeof(TService), implementationFactory, lifetime);

        services.Add(descriptorToAdd);

        return services;
    }
    
    public static IServiceCollection Remove<TService>(
        this IServiceCollection services)
        where TService : class
    {
        var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(TService));

        if (dbContextDescriptor is null)
            return services;
        
        services.Remove(dbContextDescriptor);

        return services;
    }
}