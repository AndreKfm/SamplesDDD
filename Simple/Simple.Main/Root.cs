using Simple.Domain.Ports;
using Simple.Domain.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Infrastructure.Root
{
    public class Root : IRoot
    {
        private readonly IOutput _output;

        public Root(IOutput output)
        {
            _output = output;
        }

        public async Task Main(CancellationToken token)
        {
            int count = 0;
            while (token.IsCancellationRequested == false)
            {
                _output.WriteString($"XXXRunning: {++count}");
                await Task.Delay(1000);
            }
        }
    }
}
