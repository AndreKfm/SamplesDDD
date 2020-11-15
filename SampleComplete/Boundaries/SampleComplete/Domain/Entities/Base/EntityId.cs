using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Entities.Base
{
    public record EntityId
    {
        public Guid Id { get; }

        public EntityId()
        {
            Id = Guid.NewGuid();
        }

        public EntityId(Guid value)
        {
            if (value == default)
                throw new ArgumentException("Entity id cannot be empty", nameof(value));
            Id = value;
        }
    }
}
