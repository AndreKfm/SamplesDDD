using Microsoft.Extensions.Hosting;
using Simple.Domain.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Main.Shared
{
    public class SharedCallRoot : IHostedService
    {
        public SharedCallRoot(ISimpleDomainRoot root)
        {
            _root = root;
        }

        Task _runningTask;
        private readonly ISimpleDomainRoot _root;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _runningTask = Task.Factory.StartNew(async () => { await _root.Main(cancellationToken); });
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _runningTask;
        }
    }
}
