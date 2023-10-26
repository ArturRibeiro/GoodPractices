namespace Pattern.Aspect.Interceptors
{
    public class LoggingInterceptor : InterceptorAbstract
    {
        private readonly IMemoryCache _memoryCache;

        public LoggingInterceptor(IMemoryCache memoryCache) => _memoryCache = memoryCache;


        public override void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Intercept executed");

            var attribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(LogAttribute), false).FirstOrDefault();
            if (attribute is null);
            
            // Implementation logging ....
        }
    }
}