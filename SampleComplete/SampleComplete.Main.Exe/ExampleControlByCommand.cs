using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SampleComplete.Domain.Commands;
using SampleComplete.Domain.Ports;
using System.Threading.Tasks;
using System.Collections.Generic;

internal class ExampleControlByCommand
{

    public static async Task SwitchPermanentlyBetweenAllOutputs(IHost host)
    {
        Task waitShutdown = host.WaitForShutdownAsync();
        var outputServices = host.Services.GetService<IChangeOutput>();
        IOutputService? outputService = host.Services.GetService<IOutputService>();
        List<string>? outputList = outputService?.AvailableOutputs().ToList();
        int index = 0;
        if (outputList == null)
            return; 

        for (; ; )
        {
            await Task.WhenAny(waitShutdown, Task.Delay(2000));
            if (waitShutdown.IsCompleted)
                break;
            outputServices?.SetActiveOutput(outputList[index]);
            if (++index >= outputList.Count()) index = 0;
        }
    }
}