using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Infrastructure.Adapters
{
    public class OutputTypes : IOutputTypes
    {
        IEnumerable<(string, Type)> IOutputTypes.ServiceTypes()
        {
            return new[] { ("ToConsole", typeof(OutputToConsole)), ("ToFileSimulated", typeof(OutputToFileSimulated)) };
        }
    }
}
