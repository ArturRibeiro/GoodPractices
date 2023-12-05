namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public static class ListExtension
{
    public static IEnumerable<T> RandomSelection<T>(this Result<List<T>> @this, short amount)
    {
        var random = new Random();
        return @this.Value.OrderBy(x => random.Next()).Take(amount).ToList();
    }
}