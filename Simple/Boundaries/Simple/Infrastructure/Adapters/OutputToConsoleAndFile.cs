using Microsoft.Extensions.Logging;
using Simple.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Infrastructure.Adapters
{
    public class OutputToConsole : IOutput
    {
        private readonly ILogger<OutputToFileSimulated> _logger;
        public OutputToConsole(ILogger<OutputToFileSimulated> logger)
        {
            logger.LogInformation("Output to simulated file");
            _logger = logger;

        }
        public void Dispose()
        {
            Console.WriteLine("### DISPOSING ###");
        }

        public void WriteString(string output)
        {
            Console.WriteLine(output);
        }
    }

    public class OutputToFileSimulated : IOutput
    {
        private readonly ILogger<OutputToFileSimulated> _logger;
        public OutputToFileSimulated(ILogger<OutputToFileSimulated> logger)
        {
            logger.LogInformation("Output to simulated file");
            _logger = logger;
        }
        public void Dispose()
        {
            Console.WriteLine("### DISPOSING ###");
        }

        public void WriteString(string output)
        {
            Console.WriteLine($"Write to file: {output}");
        }
    }
}
