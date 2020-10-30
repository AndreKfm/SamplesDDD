using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Domain.Ports
{
    public interface IOutput : IDisposable
    {
        public void WriteString(string output);
    }
}
