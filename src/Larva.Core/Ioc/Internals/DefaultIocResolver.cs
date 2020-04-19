using System;

namespace Larva.Core.Ioc.Internals
{
    /// <summary>
    /// 默认IoC解析器
    /// </summary>
    internal class DefaultIocResolver : IIocResolver
    {
        public DefaultIocResolver() { }

        public bool IsRegistered(Type serviceType, string serviceName = null)
        {
            return IocContainer.Instance.IsRegistered(serviceType, serviceName);
        }

        public bool IsRegistered<TService>(string serviceName = null) where TService : class
        {
            return IocContainer.Instance.IsRegistered<TService>(serviceName);
        }

        public object Resolve(Type serviceType)
        {
            return IocContainer.Instance.Resolve(serviceType);
        }

        public TService Resolve<TService>() where TService : class
        {
            return IocContainer.Instance.Resolve<TService>();
        }

        public object ResolveNamed(string serviceName, Type serviceType)
        {
            return IocContainer.Instance.ResolveNamed(serviceName, serviceType);
        }

        public TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return IocContainer.Instance.ResolveNamed<TService>(serviceName);
        }
    }
}
