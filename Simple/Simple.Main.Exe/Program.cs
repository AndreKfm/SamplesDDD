using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simple.Domain;
using Simple.Domain.Ports;
using Simple.Domain.Root;
using Simple.Infrastructure;
using Simple.Infrastructure.Adapters;
using Simple.Infrastructure.Root;
using Simple.Main.Shared;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

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
                    services.AddSingleton<ISimpleDomainRoot, SimpleDomainMain>(); // This is the port we want to use in our root object
                    services.AddHostedService<SharedCallRoot>(); // This is a generic wrapper for main root
                }).
                Build().Run();

        }
    }
}
