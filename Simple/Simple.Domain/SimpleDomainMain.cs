using Simple.Domain.Main;
using Simple.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Domain
{
    public class SimpleDomainMain : ISimpleDomainMainEntry
    {
        private readonly IOutput _output;

        public SimpleDomainMain(IOutput output)
        {
            _output = output;
        }

        /// <summary>
        /// Main loop of the Simple.Domain
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Main(CancellationToken cancellationToken)
        {

            int count = 0;
            while (cancellationToken.IsCancellationRequested == false)
            {
                _output.WriteString($"Running: {++count}");
                await Task.Delay(1000);
            }
        }


    }
}
