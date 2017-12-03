using Newtonsoft.Json;

namespace IpInfo.Api.Serializers.Interface
{
    public interface IJsonSerializer
    {
        JsonSerializer Serializer { get; }
    }
}
