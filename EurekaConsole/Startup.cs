using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Discovery.Client;

namespace EurekaConsole
{
    public class Startup
    {
        private static IConfigurationRoot _configuration;
        public IServiceProvider ServiceProvider;

        public void Start()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfiguration>(_configuration);
            serviceCollection.AddDiscoveryClient(_configuration);
        }
    }
}
