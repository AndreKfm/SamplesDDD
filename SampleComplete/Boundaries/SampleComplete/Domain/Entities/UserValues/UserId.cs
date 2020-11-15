using SampleComplete.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Entities.UserValues
{
    public record UserId
    {
        EntityId _id;

        public UserId(EntityId idInit)
        {
            _id = idInit;
        }


        public bool IsSame(EntityId id) 
        { 
            EntityId local = id; return local.Id == _id.Id; 
        }
    }
}
