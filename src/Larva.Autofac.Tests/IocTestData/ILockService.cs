using System;

namespace Larva.Autofac.Tests.IocTestData
{
    public interface ILockService
    {
        void AddLocker(string locker);

        void Execute(string locker, Action action);

        T Execute<T>(string locker, Func<T> action);
    }
}