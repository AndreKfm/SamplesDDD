using SampleComplete.Domain.Events;
using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Entities.Base
{

    public interface IAggregateRoot
    { }

    public record Entity : IAggregateRoot
    {
        static List<Event> EmptyList = new List<Event>();

        public EntityId Id { get; }

        public Entity(IEventBus eventBus)
        {
            _eventList = EmptyList;
            _eventBus = eventBus;
            Id = new EntityId();
        }

        public void RaiseEvent(Event newEvent)
        {
            if (_eventList == null) 
                _eventList = new List<Event>();
            _eventList.Add(newEvent);
        }

        public void Publish()
        {
            _eventList.ForEach(_eventBus.Publish);

            if (_eventList.Count > 0) 
                _eventList.Clear();
        }

        List<Event> _eventList { get; set; }
        IEventBus _eventBus;
    }
}
