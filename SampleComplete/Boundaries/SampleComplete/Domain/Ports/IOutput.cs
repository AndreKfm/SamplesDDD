using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Ports
{
    public interface IOutput : IDisposable
    {
        public void WriteString(string output);
    }


    public interface IOutputService : IDisposable
    {
        public IEnumerable<string> AvailableOutputs();
        public IOutput GetOutput(string whichOutput);
    }


}
