﻿using SampleComplete.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Ports
{
    interface IEventBus
    {
        void Publish(Event newEvent);
    }
}
