using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICache.Api.Extensions
{
    public class SerializerSettings
    {
        public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}