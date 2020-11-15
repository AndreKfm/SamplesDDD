using Microsoft.Extensions.Logging;
using SampleComplete.Domain.Commands;
using SampleComplete.Domain.Main;
using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleComplete.Domain
{

    public class OutputServices : IChangeOutput, IOutput
    {
        private IOutputService _outputService;
        private readonly ILogger<OutputServices> _logger;
        private IOutput _activeOutput; 
        

        public OutputServices(IOutputService outputService, ILogger<OutputServices> logger)
        {
            _outputService  = outputService;
            _logger = logger;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose OutputServices");
        }

        public void SetActiveOutput(string whichOutput)
        {
            lock(this)
            {
                _activeOutput = _outputService.GetOutput(whichOutput);
            }

            _logger.LogInformation($"Output to {whichOutput}");

        }

        public void WriteString(string output)
        {
            IOutput currentOutput; 
            
            lock(this)
            {
                currentOutput = _activeOutput;
            }

            if (currentOutput == null)
                return;

            currentOutput.WriteString(output);
        }
    }

    public class SimpleDomainMain : ISimpleDomainMainEntry
    {
        private IOutput _output;

        public SimpleDomainMain(IOutput output)
        {
            _output = output;
        }

        /// <summary>
        /// Main loop of the SampleComplete.Domain
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Main(CancellationToken cancellationToken)
        {

            int count = 0;
            while (cancellationToken.IsCancellationRequested == false)
            {
                _output.WriteString($"Running: {++count}");
                await Task.Delay(500);
            }
        }

    }
}
