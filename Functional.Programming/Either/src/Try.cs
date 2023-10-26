namespace Pattern.Functional.Programming
{
    public static class Try<T>
    {
        public static Either<Exception, T> Cath(Func<T> @try)
        {
            try
            {
                return new Right<Exception, T>(@try());
            }
            catch (Exception e)
            {
                return new Left<Exception, T>(e);
            }
        }
    }
}