using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Ports
{
    public interface IOutputTypes
    {
        IEnumerable<(String outputName, Type outputType)> ServiceTypes();
    }


}
