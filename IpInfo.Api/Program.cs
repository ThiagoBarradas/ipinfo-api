using IpInfo.Api.Utilities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace IpInfo.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationUtility.GetApplicationTitle());
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:505")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
