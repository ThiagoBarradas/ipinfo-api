namespace IpInfo.Api.Utilities.Interface
{
    public interface IConfigurationUtility
    {
        string IpInfoServiceUrl { get; }

        int IpInfoServiceTimeoutInSeconds { get; }

        string RollbarAccessToken { get; }

        string RollbarEnvironment { get; }
    }
}
