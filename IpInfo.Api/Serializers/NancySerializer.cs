using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace IpInfo.Api.Serializers
{
    public class NancySerializer : JsonSerializer
    {
        public NancySerializer()
        {
            this.ContractResolver = new CamelCasePropertyNamesContractResolver();
            this.Formatting = Formatting.Indented;
            this.NullValueHandling = NullValueHandling.Ignore;
            this.Converters.Add(new StringEnumConverter());
        }
    }
}
