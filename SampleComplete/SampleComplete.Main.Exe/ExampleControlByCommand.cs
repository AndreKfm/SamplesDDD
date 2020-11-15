using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SampleComplete.Domain.Commands;
using SampleComplete.Domain.Ports;
using System.Threading.Tasks;

internal class ExampleControlByCommand
{

    public static async Task SwitchPermanentlyBetweenAllOutputs(IHost host)
    {
        Task waitShutdown = host.WaitForShutdownAsync();
        var outputServices = host.Services.GetService<IChangeOutput>();
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
}