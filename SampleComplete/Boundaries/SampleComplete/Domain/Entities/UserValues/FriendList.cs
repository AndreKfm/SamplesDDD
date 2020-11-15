using SampleComplete.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Entities.UserValues
{
    internal record FriendList
    {
        public FriendList() { Friends = new List<UserId>(); }
        public List<UserId> Friends { get; }
    }
}
