using SampleComplete.Domain.Entities.Base;
using SampleComplete.Domain.Entities.UserValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Events
{
    public record Event ();

    record UserNameChanged(UserId userId, string newUserName, string oldUserName) : Event;
    record NewUserCreated(UserId userId) : Event;
    record NewFriend(UserId userId, UserId friend) : Event;
}
