using IpInfo.Api.Serializers.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace IpInfo.Api.Serializers
{
    public class CamelCaseJsonSerializer : IJsonSerializer
    {
        public JsonSerializer Serializer
        {
            get
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
                serializer.Formatting = Formatting.Indented;
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.Converters.Add(new StringEnumConverter());
                return serializer;
            }
        }
    }
}
