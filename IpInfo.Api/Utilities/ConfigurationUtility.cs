using IpInfo.Api.Utilities.Interface;
using Microsoft.Extensions.Configuration;

namespace IpInfo.Api.Utilities
{
    public class ConfigurationUtility : IConfigurationUtility
    {
        public IConfigurationRoot RootConfiguration => Startup.Configuration;
        
        public string IpInfoServiceUrl => this.RootConfiguration["IpInfoService:Url"];

        public int IpInfoServiceTimeoutInSeconds => int.Parse(this.RootConfiguration["IpInfoService:TimeoutInSeconds"]);
    }
}
