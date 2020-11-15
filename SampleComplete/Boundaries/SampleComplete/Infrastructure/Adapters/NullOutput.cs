using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Infrastructure.Adapters
{
    internal class NullOutput : IOutput
    {
        public void Dispose()
        {
        }

        public void WriteString(string output)
        {
            Console.WriteLine($"# NULL # : {output}");
        }
    }
}
