using SampleComplete.Domain.Entities;
using SampleComplete.Domain.Entities.UserValues;
using SampleComplete.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Infrastructure.AdaptersRepositories
{
    class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }
        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Load(UserId id)
        {
            throw new NotImplementedException();
        }
    }
}
