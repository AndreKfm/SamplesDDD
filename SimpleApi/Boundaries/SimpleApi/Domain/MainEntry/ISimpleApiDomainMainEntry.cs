﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApi.Domain.Main
{
    public interface ISimpleDomainMainEntry
    {
       public Task Main(CancellationToken cancellationToken);
    }
}
