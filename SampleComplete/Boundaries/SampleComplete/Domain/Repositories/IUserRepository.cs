using SampleComplete.Domain.Entities;
using SampleComplete.Domain.Entities.Base;
using SampleComplete.Domain.Entities.UserValues;
using SampleComplete.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComplete.Domain.Repositories
{
    // 
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Load(UserId id);
        Task Add(User user);

        Task<bool> Exists(User user);
    }
}
