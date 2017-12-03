namespace IpInfo.Api.Utilities.Interface
{
    public interface IConfigurationUtility
    {
        string IpInfoServiceUrl { get; }

        int IpInfoServiceTimeoutInSeconds { get; }
    }
}
