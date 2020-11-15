using SampleComplete.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Repositories.Base
{
    public interface IRepository<T>  where T : IAggregateRoot
    {
        
    }
}
