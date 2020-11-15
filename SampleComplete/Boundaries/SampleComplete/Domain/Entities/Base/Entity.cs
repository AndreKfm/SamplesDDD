using SampleComplete.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Entities.Base
{
    public record Entity
    {
        public EntityId Id { get; }

        public Entity()
        {
            _eventList = new List<Event>();
        }

        public void RaiseEvent(Event newEvent)
        {
            _eventList.Add(newEvent);
        }

        List<Event> _eventList { get; }
    }
}
