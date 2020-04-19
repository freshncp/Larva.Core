using System;
using Larva.Core.Ioc.Events;

namespace Larva.Core.Ioc
{
    /// <summary>
    /// IoC容器
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        void RegisterType(Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton);

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementer"></typeparam>
        void Register<TService, TImplementer>(string serviceName = null, LifetimeScope life = LifetimeScope.Singleton)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>
        /// 注册实例
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="serviceName"></param>
        /// <typeparam name="TService"></typeparam>
        void RegisterInstance<TService>(TService instance, string serviceName = null)
            where TService : class;

        /// <summary>
        /// 构建
        /// </summary>
        void Build();

        /// <summary>
        /// 是否已注册
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        bool IsRegistered(Type serviceType, string serviceName = null);

        /// <summary>
        /// 是否已注册
        /// </summary>
        /// <param name="serviceName"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        bool IsRegistered<TService>(string serviceName = null)
            where TService : class;

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService Resolve<TService>()
            where TService : class;

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        object Resolve(Type serviceType);

        /// <summary>
        /// 解析已命名的
        /// </summary>
        /// <param name="serviceName"></param>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService ResolveNamed<TService>(string serviceName)
            where TService : class;

        /// <summary>
        /// 解析已命名的
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        object ResolveNamed(string serviceName, Type serviceType);

        /// <summary>
        /// 服务类型注册中事件
        /// </summary>
        event EventHandler<ServiceTypeRegisteringEventArgs> OnServiceTypeRegistering;

        /// <summary>
        /// 服务实例注册中事件
        /// </summary>
        event EventHandler<ServiceInstanceRegisteringEventArgs> OnServiceInstanceRegistering;
    }
}
