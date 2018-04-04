using IpInfo.Api.Utilities.Interface;
using Nancy;
using System;

namespace IpInfo.Api.Loggers.Interface
{
    public interface IRequestLogger
    {
        void Setup(IConfigurationUtility configurationUtility);

        void LogData(NancyContext context, Exception exception = null);
    }
}
