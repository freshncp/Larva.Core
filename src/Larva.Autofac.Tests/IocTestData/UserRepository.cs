using System;

namespace Larva.Autofac.Tests.IocTestData
{
    [Larva.Core.Ioc.IocService]
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            Console.WriteLine($"User {user.Name} added.");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}