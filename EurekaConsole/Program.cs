using System;
using System.Net.Http;
using Steeltoe.Common.Discovery;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EurekaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var startUp = new Startup();
            startUp.Start();
            var discoveryClient = startUp.ServiceProvider.GetService<IDiscoveryClient>();
            var configuration = startUp.ServiceProvider.GetService<IConfiguration>();

           
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            var address = configuration.GetValue<string>("WeatherApiUrl")+"weather";
            using (var httpResponseMessage = new HttpClient(handler, false).GetAsync(address).Result)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }



            Console.ReadLine();
        }
    }
}
