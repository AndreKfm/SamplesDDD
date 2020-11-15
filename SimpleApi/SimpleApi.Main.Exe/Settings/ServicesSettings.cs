using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{

    public enum OutputDestinations
    {
        Console, File
    }

    public class ServicesSettings
    {
        public OutputDestinations OutputDestination { get; set; }
    }
}
