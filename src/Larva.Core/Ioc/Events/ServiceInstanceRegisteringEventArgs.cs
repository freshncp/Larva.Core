using System;

namespace Larva.Core.Ioc.Events
{
    /// <summary>
    /// 服务实例注册中
    /// </summary>
    public class ServiceInstanceRegisteringEventArgs : EventArgs
    {
        /// <summary>
        /// 服务实例注册中
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">服务实例</param>
        /// <param name="serviceName">服务名</param>
        public ServiceInstanceRegisteringEventArgs(Type serviceType, object instance, string serviceName)
        {
            ServiceType = serviceType;
            Instance = instance;
            ServiceName = serviceName;
            Life = LifetimeScope.Singleton;
        }

        /// <summary>
        /// 服务类型
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// 服务实例
        /// </summary>
        public object Instance { get; private set; }

        internal object NewInstance { get; private set; }

        /// <summary>
        /// 服务名
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// 生命期范围
        /// </summary>
        public LifetimeScope Life { get; private set; }

        /// <summary>
        /// 设置新实例
        /// </summary>
        /// <param name="newInstance"></param>
        public void SetNewInstance(object newInstance)
        {
            NewInstance = newInstance;
        }
    }
}
