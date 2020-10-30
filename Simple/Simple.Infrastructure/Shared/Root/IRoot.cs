using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Domain.Root
{
    public interface IRoot
    {
        public Task Main(CancellationToken cancellationToken);
    }
}
