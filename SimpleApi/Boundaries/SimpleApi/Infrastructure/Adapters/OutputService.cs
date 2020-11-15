using SimpleApi.Domain.Ports;
using SimpleApi.Infrastructure.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple
{

    public class OutputService : IOutputService
    {
        private readonly IServiceProvider _provider;
        private readonly IOutputTypes _types;

        public OutputService(IServiceProvider provider, IOutputTypes types)
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
