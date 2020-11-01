using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simple.Domain;
using Simple.Domain.Main;
using Simple.Domain.Ports;
using Simple.Infrastructure.Adapters;
using Simple.Main.Shared;
using System;

namespace Simple
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Host.CreateDefaultBuilder(args).
                ConfigureAppConfiguration((hostContext, config)=>
                {
                    //config.SetBasePath(Environment.CurrentDirectory); // Default
                    //config.AddJsonFile("appsettings.json", optional: false);
                    //config.AddEnvironmentVariables();
                }).
                ConfigureServices((context, services) =>
                {
                    var settings = new ServicesSettings();
                    context.Configuration.GetSection("ServicesSettings").Bind(settings);
                                      
                   
                    if (settings.OutputDestination == OutputDestinations.File)
                        services.AddSingleton<IOutput, OutputToFileSimulated>(); // This is the port we want to use in our root object
                    else 
                        services.AddSingleton<IOutput, OutputToConsole>(); // This is the port we want to use in our root object
                    services.AddSingleton<ISimpleDomainMainEntry, SimpleDomainMain>(); // This is the main entry of the domain
                    services.AddHostedService<SharedCallRoot>(); // This is a generic wrapper for main root
                }).
                Build().Run();

        }
    }
}
