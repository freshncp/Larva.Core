using System;

namespace Larva.Autofac.Tests.IocTestData
{
    [Larva.Core.Ioc.IocService]
    public class LockService : ILockService
    {
        public void AddLocker(string locker)
        { }

        public void Execute(string locker, Action action)
        {
            action();
        }

        public T Execute<T>(string locker, Func<T> action)
        {
            return action();
        }
    }
}