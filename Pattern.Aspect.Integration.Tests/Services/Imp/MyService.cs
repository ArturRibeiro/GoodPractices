namespace Pattern.Aspect.Integration.Tests.Services.Imp
{
    public class MyService : IMyService
    {
        [Log]
        public void MyImplementation(string parameter)
        {
            
        }
    }
}