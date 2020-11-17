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
    // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Load(UserId id);
        Task Add(User user);

        Task<bool> Exists(User user);
    }
}
