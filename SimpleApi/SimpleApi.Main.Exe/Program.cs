﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simple;
using SimpleApi.Api;
using SimpleApi.Domain;
using SimpleApi.Domain.Commands;
using SimpleApi.Domain.Main;
using SimpleApi.Domain.Ports;
using SimpleApi.Infrastructure.Adapters;
using SimpleApi.Main.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



internal class Program 
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var host = Host.CreateDefaultBuilder(args).
            ConfigureServices((context, services) =>
            {
                services.AddSingleton<OutputToConsole, OutputToConsole>(); // This is the main entry of the domain
                services.AddSingleton<OutputToFileSimulated, OutputToFileSimulated>(); // This is the main entry of the domain



                services.AddSingleton<OutputService, OutputService>();
                services.AddSingleton<OutputServices, OutputServices>();
                services.AddSingleton<IChangeOutput>(s => s.GetRequiredService<OutputServices>());
                services.AddSingleton<IOutput>(s => s.GetRequiredService<OutputServices>());
                services.AddSingleton<IOutputService>(s => (IOutputService)s.GetRequiredService<OutputService>());
                services.AddSingleton<IOutputTypes, OutputTypes>();

                services.AddSingleton<ISimpleDomainMainEntry, SimpleDomainMain>(); // This is the main entry of the domain
                services.AddHostedService<SharedCallRoot>(); // This is a generic wrapper for main root
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).Build();
        Task.Run(() =>
        {
            host.Services.GetService<IChangeOutput>().SetActiveOutput(host.Services.GetService<IOutputService>().AvailableOutputs().First());
            //await ExampleControlByCommand.SwitchPermanentlyBetweenAllOutputs(host);
        });


        host.Run();

        Console.ReadLine();
    }


}


