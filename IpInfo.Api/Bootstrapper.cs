using IpInfo.Api.Handlers;
using IpInfo.Api.Managers;
using IpInfo.Api.Serializers;
using IpInfo.Api.Utilities;
using IpInfo.Api.Utilities.Interface;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.ErrorHandling;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace IpInfo.Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            this.AddStopwatch(pipelines);
            this.EnableCors(pipelines);
            this.EnableCSRF(pipelines);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // Utilities
            container.Register<IConfigurationUtility, ConfigurationUtility>().AsSingleton();
            container.Register<JsonSerializer, NancySerializer>().AsSingleton();
            container.Register<IStatusCodeHandler, StatusCodeHandler>().AsSingleton();
            container.Register<IIpInfoManager, IpInfoManager>().AsSingleton();

            base.ConfigureApplicationContainer(container);
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
        }

        private void EnableCors(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToStartOfPipeline((context) =>
            {
                context.Response
                       .WithHeader("Access-Control-Allow-Origin", "*")
                       .WithHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT,PATCH,DELETE")
                       .WithHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
            });
        }

        private void AddStopwatch(IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline((context) =>
            {
                var stopwatch = Stopwatch.StartNew();
                context.Items.Add("Stopwatch", stopwatch);
                return null;
            });

            pipelines.AfterRequest.AddItemToStartOfPipeline((context) =>
            {
                object objStopwatch;
                context.Items.TryGetValue("Stopwatch", out objStopwatch);
                if (objStopwatch != null)
                {
                    Stopwatch stopwatch = (Stopwatch)objStopwatch;
                    stopwatch.Stop();
                    context.Response.Headers.Add("X-Internal-Time", stopwatch.ElapsedMilliseconds.ToString());
                }
            });
        }

        private void EnableCSRF(IPipelines pipelines)
        {
            Nancy.Security.Csrf.Enable(pipelines);
        }
    }
}