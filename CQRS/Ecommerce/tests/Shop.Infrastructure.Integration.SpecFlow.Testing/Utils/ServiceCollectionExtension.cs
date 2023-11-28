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
}