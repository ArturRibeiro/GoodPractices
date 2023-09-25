namespace Pattern.Aspect.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddInterceptorScoped<TInterface, TImplementation, TInterceptor>(this IServiceCollection services)
            where TImplementation : class, TInterface
            where TInterceptor : InterceptorAbstract
        {
            services.AddScoped<IInterceptor, TInterceptor>();
            services.AddSingleton(new ProxyGenerator());
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                return proxyGenerator.CreateInterfaceProxyWithTarget
                (
                    typeof(TInterface)
                    , serviceProvider.GetRequiredService<TImplementation>()
                    , serviceProvider.GetServices<IInterceptor>().ToArray()
                );
            });
        }
    }
}