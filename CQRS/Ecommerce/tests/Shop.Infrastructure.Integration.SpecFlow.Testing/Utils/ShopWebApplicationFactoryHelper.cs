using System.Text;

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
}