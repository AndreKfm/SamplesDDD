using SampleComplete.Domain.Events;
using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Infrastructure.Adapters
{
    public class EventBus : IEventBus
    {
        public void Publish(Event newEvent)
        {
            Console.WriteLine($"Publish event: {newEvent}");
        }
    }
}
