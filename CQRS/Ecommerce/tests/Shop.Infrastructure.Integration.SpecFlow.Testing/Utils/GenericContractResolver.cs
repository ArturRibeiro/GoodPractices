using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Utils;

public class GenericContractResolver<T> : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        if (property.UnderlyingName == nameof(Result<T>.Value))
        {
            property.PropertyName = typeof(T).Name;
        }
        return property;
    }
}