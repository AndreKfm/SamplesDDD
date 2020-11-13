using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleApi.Domain;
using SimpleApi.Domain.Main;
using SimpleApi.Domain.Ports;
using SimpleApi.Infrastructure.Adapters;
using SimpleApi.Main.Shared;
using System;

namespace Simple
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Host.CreateDefaultBuilder(args).
                ConfigureServices((context, services) =>
                {
                    AddSingletonForOutput(context, services);

                    services.AddSingleton<ISimpleDomainMainEntry, SimpleDomainMain>(); // This is the main entry of the domain
                    services.AddHostedService<SharedCallRoot>(); // This is a generic wrapper for main root
                }).
                Build().Run();
        }

        private static void AddSingletonForOutput(HostBuilderContext context, IServiceCollection services)
        {
            // Based on the configuration in appsettings.json we will switch between
            // output adapter - either file or simulated file output. This won't
            // change any domain code and implementation - but pure infrastructure changes
            // by configuration.

            var settings = new ServicesSettings();
            context.Configuration.GetSection("ServicesSettings").Bind(settings); // We load it manually without injection

            if (settings.OutputDestination == OutputDestinations.File)
                services.AddSingleton<IOutput, OutputToFileSimulated>(); // This is the port we want to use in our root object
            else
                services.AddSingleton<IOutput, OutputToConsole>(); // This is the port we want to use in our root object
        }
    }
}
