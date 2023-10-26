using Pattern.Aspect.Integration.Testing.Services;
using Pattern.Aspect.Integration.Testing.Services.Imp;

namespace Pattern.Aspect.Integration.Testing
{
    public class LogInterceptorTests
    {
        private ServiceProvider provider;

        public LogInterceptorTests()
        {
            var services = new ServiceCollection();
            services.AddInterceptorScoped<IMyService, MyService, LoggingInterceptor>();
            services.AddMemoryCache();
            this.provider = services.BuildServiceProvider();
        }

        [Theory(DisplayName = "Should run cache when method is called")]
        [InlineData("my value 1")]
        [InlineData("my value 2")]
        public void InterceptExecuteCache(string value)
        {
            // Arrange
            var myService = provider.GetRequiredService<IMyService>();
            
            // Act
             myService.MyImplementation(value);

            // Assert's
        }
    }
}