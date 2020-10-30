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
                ConfigureServices(services =>
                {
                    //services.AddSingleton<IOutput, OutputToConsole>(); // This is the port we want to use in our root object
                    services.AddSingleton<IOutput, OutputToFileSimulated>(); // This is the port we want to use in our root object
                    services.AddSingleton<ISimpleDomainMainEntry, SimpleDomainMain>(); // This is the main entry of the domain
                    services.AddHostedService<SharedCallRoot>(); // This is a generic wrapper for main root
                }).
                Build().Run();

        }
    }
}
