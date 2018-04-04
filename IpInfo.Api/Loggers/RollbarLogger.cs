using IpInfo.Api.Loggers.Interface;
using IpInfo.Api.Utilities.Interface;
using Microsoft.Extensions.Options;
using RollbarDotNet;
using RollbarDotNet.Abstractions;
using RollbarDotNet.Builder;
using RollbarDotNet.Configuration;
using System;

namespace IpInfo.Api.Loggers
{
    public class RollbarLogger : IExceptionLogger
    {
        private Rollbar Rollbar { get; set; }

        public RollbarLogger(IConfigurationUtility configurationUtility)
        {
            var rollbarOptions = Options.Create(new RollbarOptions
            {
                AccessToken = configurationUtility.RollbarAccessToken,
                Environment = configurationUtility.RollbarEnvironment
            });

            this.Rollbar = new Rollbar(
                new IBuilder[] {
                    new ConfigurationBuilder(rollbarOptions),
                    new EnvironmentBuilder(new SystemDateTime()),
                    new NotifierBuilder()
                },
                new IExceptionBuilder[] {
                    new ExceptionBuilder()
                },
                new RollbarClient(rollbarOptions)
            );
        }

        public void LogCritical(Exception exception)
        {
            this.Rollbar.SendException(RollbarLevel.Critical, exception);
        }

        public void LogInfo(string message)
        {
            this.Rollbar.SendMessage(RollbarLevel.Info, message);
        }
    }
}