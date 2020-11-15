using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Commands
{
    public interface IChangeOutput
    {
        void SetActiveOutput(string whichOutput);
    }
}
