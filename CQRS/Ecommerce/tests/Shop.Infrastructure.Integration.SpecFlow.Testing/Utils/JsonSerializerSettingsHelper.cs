using Newtonsoft.Json;

namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public static class JsonSerializerSettingsHelper<T>
{
    public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        { ContractResolver = new GenericContractResolver<T>() };
}