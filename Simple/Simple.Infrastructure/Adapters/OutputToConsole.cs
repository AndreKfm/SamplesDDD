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
