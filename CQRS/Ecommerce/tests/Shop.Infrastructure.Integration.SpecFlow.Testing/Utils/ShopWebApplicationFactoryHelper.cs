namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public static class ShopWebApplicationFactoryHelper
{
    internal static Func<HttpMethod, string, HttpRequestMessage> CreateHttpRequestMessage = (httpMethod, json)
        => new HttpRequestMessage
        {
            Method = httpMethod,
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
            RequestUri = new Uri("http://localhost:5207/graphql")
        };

    internal static HttpResponseMessage SuccessStatusCode(this HttpResponseMessage @this)
    {
        @this.EnsureSuccessStatusCode();
        return @this;
    }
    
    internal static string ReadAsStringAsync<T>(this HttpResponseMessage @this,
        string queryName)
    {
        var responseString = @this.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var obj = JObject.Parse(responseString);
        return obj["data"][queryName].ToString();
    }
    
    internal static T ParseGraphQlResultToJson<T>(this string @json) => JsonConvert.DeserializeObject<T>(@json);

    internal static Result<T> SetResult<T>(this T readModel) => new(readModel);
}