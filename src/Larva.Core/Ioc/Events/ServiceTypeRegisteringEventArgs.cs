using System;

namespace Larva.Core.Ioc.Events
{
    /// <summary>
    /// 服务类型注册中
    /// </summary>
    public class ServiceTypeRegisteringEventArgs : EventArgs
    {
        /// <summary>
        /// 服务类型注册中
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="serviceName">ServiceName</param>
        public ServiceTypeRegisteringEventArgs(Type serviceType, Type implementationType, string serviceName)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            ServiceName = serviceName;
            Life = LifetimeScope.Singleton;
        }

        /// <summary>
        /// 服务类型
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// 实现类型
        /// </summary>
        public Type ImplementationType { get; private set; }

        internal Type NewImplementationType { get; private set; }

        /// <summary>
        /// 服务名
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// 生命期范围
        /// </summary>
        public LifetimeScope Life { get; private set; }

        /// <summary>
        /// 设置新实现类型
        /// </summary>
        /// <param name="newImplementationType"></param>
        public void SetNewImplementationType(Type newImplementationType)
        {
            NewImplementationType = newImplementationType;
        }
    }
}
