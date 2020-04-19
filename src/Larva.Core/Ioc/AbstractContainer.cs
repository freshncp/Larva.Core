using System;
using Larva.Core.Ioc.Events;

namespace Larva.Core.Ioc
{
    /// <summary>
    /// IoC容器抽象类
    /// </summary>
    public abstract class AbstractContainer : IContainer
    {
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        public abstract void RegisterType(Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton);

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        public void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton)
        {
            if (OnServiceTypeRegistering != null)
            {
                var e = new ServiceTypeRegisteringEventArgs(serviceType, implementationType, serviceName);
                OnServiceTypeRegistering(this, e);
                if (e.NewImplementationType != null)
                {
                    implementationType = e.NewImplementationType;
                }
            }
            InnerRegisterType(serviceType, implementationType, serviceName, life);
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        protected abstract void InnerRegisterType(Type serviceType, Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementer"></typeparam>
        /// <returns></returns>
        public void Register<TService, TImplementer>(string serviceName, LifetimeScope life)
            where TService : class
            where TImplementer : class, TService
        {
            RegisterType(typeof(TService), typeof(TImplementer), serviceName, life);
        }

        /// <summary>
        /// 注册实例
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="serviceName"></param>
        /// <typeparam name="TService"></typeparam>
        public void RegisterInstance<TService>(TService instance, string serviceName)
            where TService : class
        {
            if (OnServiceInstanceRegistering != null)
            {
                var e = new ServiceInstanceRegisteringEventArgs(typeof(TService), instance, serviceName);
                OnServiceInstanceRegistering(this, e);
                if (e.NewInstance != null)
                {
                    instance = (TService)e.NewInstance;
                }
            }
            InnerRegisterInstance<TService>(instance, serviceName);
        }

        /// <summary>
        /// 注册实例
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="serviceName"></param>
        /// <typeparam name="TService"></typeparam>
        protected abstract void InnerRegisterInstance<TService>(TService instance, string serviceName)
            where TService : class;

        /// <summary>
        /// 构建
        /// </summary>    
        public abstract void Build();

        /// <summary>
        /// 是否已注册
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>        
        public abstract bool IsRegistered(Type serviceType, string serviceName = null);

        /// <summary>
        /// 是否已注册
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public bool IsRegistered<TService>(string serviceName = null) where TService : class
        {
            return IsRegistered(typeof(TService), serviceName);
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public abstract object Resolve(Type serviceType);

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public TService Resolve<TService>() where TService : class
        {
            return (TService)Resolve(typeof(TService));
        }

        /// <summary>
        /// 解析已命名的
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public abstract object ResolveNamed(string serviceName, Type serviceType);

        /// <summary>
        /// 解析已命名的
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return (TService)ResolveNamed(serviceName, typeof(TService));
        }

        /// <summary>
        /// 服务类型注册中事件
        /// </summary>
        public event EventHandler<ServiceTypeRegisteringEventArgs> OnServiceTypeRegistering;

        /// <summary>
        /// 服务实例注册中事件
        /// </summary>
        public event EventHandler<ServiceInstanceRegisteringEventArgs> OnServiceInstanceRegistering;
    }
}
