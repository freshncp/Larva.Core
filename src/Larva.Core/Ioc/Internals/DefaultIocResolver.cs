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
            return IocProxy.Instance.IsRegistered(serviceType, serviceName);
        }

        public bool IsRegistered<TService>(string serviceName = null) where TService : class
        {
            return IocProxy.Instance.IsRegistered<TService>(serviceName);
        }

        public object Resolve(Type serviceType)
        {
            return IocProxy.Instance.Resolve(serviceType);
        }

        public TService Resolve<TService>() where TService : class
        {
            return IocProxy.Instance.Resolve<TService>();
        }

        public object ResolveNamed(string serviceName, Type serviceType)
        {
            return IocProxy.Instance.ResolveNamed(serviceName, serviceType);
        }

        public TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return IocProxy.Instance.ResolveNamed<TService>(serviceName);
        }
    }
}
