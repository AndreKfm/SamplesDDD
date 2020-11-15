using SampleComplete.Domain.Entities.Base;
using SampleComplete.Domain.Entities.UserValues;
using SampleComplete.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Entities
{
    public record User : Entity
    {
        FriendList _friends { get; }// List of friends - references by their ids

        string _userName { get; set; }

        public User(IEventBus bus, string userName) : base(bus)
        {
            _friends = new FriendList();
            _userName = userName;

            RaiseEvent(new Events.NewUserCreated(new UserId(Id)));
            Publish();
        }

        void SetNewName(string newName)
        {
            string oldName = _userName;
            _userName = newName;
            RaiseEvent(new Events.UserNameChanged(new UserId(Id), newName, oldName));
        }

        public void AddFriend(User user)
        {
            var userId = new UserId(user.Id);
            if (!_friends.Friends.Contains(userId))
                _friends.Friends.Add(userId);
            RaiseEvent(new Events.NewFriend(new UserId(Id), new UserId(user.Id)));
        }
        
        bool IsSame(UserId userId)
        {
            return userId.IsSame(Id);
        }
    }
}
