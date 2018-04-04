using IpInfo.Api.Utilities.Interface;
using Microsoft.Extensions.Configuration;

namespace IpInfo.Api.Utilities
{
    public class ConfigurationUtility : IConfigurationUtility
    {
        public IConfigurationRoot RootConfiguration => Startup.Configuration;
        
        public string IpInfoServiceUrl => this.RootConfiguration["IPINFO_SERVICE_URL"];

        public int IpInfoServiceTimeoutInSeconds => int.Parse(this.RootConfiguration["IPINFO_SERVICE_TIMEOUT_IN_SECONDS"]);

        public string RollbarAccessToken => this.RootConfiguration["ROLLBAR_ACCESSTOKEN"];

        public string RollbarEnvironment => this.RootConfiguration["ROLLBAR_ENVIRONMENT"];
    }
}
