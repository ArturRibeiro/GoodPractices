namespace Pattern.Aspect
{
    public abstract class InterceptorAbstract : IInterceptor
    {
        public abstract void Intercept(IInvocation invocation);
    }
}