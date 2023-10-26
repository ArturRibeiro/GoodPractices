namespace Pattern.Aspect.Integration.Testing.Services.Imp
{
    public class MyService : IMyService
    {
        [Log]
        public void MyImplementation(string parameter)
        {
            
        }
    }
}