using System;

namespace Larva.Autofac.Tests.IocTestData
{
    public interface IUserRepository : IDisposable
    {
        void AddUser(User user);
    }
}