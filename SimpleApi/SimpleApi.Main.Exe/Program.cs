using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

namespace Simple
{

    interface IServiceTypes
    {
        IEnumerable<(String outputName, Type outputType)> ServiceTypes();
    }

    class ServiceTypes : IServiceTypes
    {
        IEnumerable<(string, Type)> IServiceTypes.ServiceTypes()
        {
            return new[] { ("ToConsole", typeof(OutputToConsole)), ("ToFileSimulated", typeof(OutputToFileSimulated)) };
        }
    }

    class OutputService : IOutputService
    {
        private readonly IServiceProvider _provider;
        private readonly IServiceTypes _types;

        public OutputService(IServiceProvider provider, IServiceTypes types)
        {
            _provider = provider;
            _types = types;
        }
        public IOutput GetOutput(string whichOutput)
        {
            var output = _types.ServiceTypes().FirstOrDefault(s => s.outputName == whichOutput).outputType;
            return (IOutput)_provider.GetService(output);
        }

        IEnumerable<string> IOutputService.AvailableOutputs()
        {
            return _types.ServiceTypes().Select(s => s.outputName);

        }

        public void Dispose()
        {
            Console.WriteLine("### --DISPOSE");
            //throw new NotImplementedException();
        }
    }


}
public class LocalStartup
{
    public LocalStartup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        //app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var host = Host.CreateDefaultBuilder(args)
            //ConfigureServices((context, services) =>
            //{
            //    //AddSingletonForOutput(context, services);

            //    //services.AddSingleton<OutputToConsole, OutputToConsole>(); // This is the main entry of the domain
            //    //services.AddSingleton<OutputToFileSimulated, OutputToFileSimulated>(); // This is the main entry of the domain



            //    //services.AddSingleton<OutputService, OutputService>();
            //    //services.AddSingleton<OutputServices, OutputServices>();
            //    //services.AddSingleton<IOutputServices>(s => s.GetRequiredService<OutputServices>());
            //    //services.AddSingleton<IOutput>(s => s.GetRequiredService<OutputServices>());
            //    //services.AddSingleton<IOutputService>(s => (IOutputService)s.GetRequiredService<OutputService>());
            //    //services.AddSingleton<IServiceTypes, ServiceTypes>();

            //    //services.AddSingleton<ISimpleDomainMainEntry, SimpleDomainMain>(); // This is the main entry of the domain
            //    //services.AddHostedService<SharedCallRoot>(); // This is a generic wrapper for main root
            //})
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).Build();
        Task.Run(async () =>
        {
                //await SwitchPermanentlyBetweenAllOutputs(host);
            });


        host.Run();

        Console.ReadLine();
    }

    private static async Task SwitchPermanentlyBetweenAllOutputs(IHost host)
    {
        Task waitShutdown = host.WaitForShutdownAsync();
        var outputServices = host.Services.GetService<IOutputServices>();
        var outputService = host.Services.GetService<IOutputService>();
        var outputList = outputService.AvailableOutputs().ToList();
        int index = 0;
        for (; ; )
        {
            await Task.WhenAny(waitShutdown, Task.Delay(2000));
            if (waitShutdown.IsCompleted)
                break;
            outputServices.SetActiveOutput(outputList[index]);
            if (++index >= outputList.Count) index = 0;
        }
    }

    private static void AddSingletonForOutput(HostBuilderContext context, IServiceCollection services)
    {
        // Based on the configuration in appsettings.json we will switch between
        // output adapter - either file or simulated file output. This won't
        // change any domain code and implementation - but pure infrastructure changes
        // by configuration.

        //var settings = new ServicesSettings();
        //context.Configuration.GetSection("ServicesSettings").Bind(settings); // We load it manually without injection

        //if (settings.OutputDestination == OutputDestinations.File)
        //    services.AddSingleton<IOutput, OutputToFileSimulated>(); // This is the port we want to use in our root object
        //else
        //    services.AddSingleton<IOutput, OutputToConsole>(); // This is the port we want to use in our root object
    }
}


