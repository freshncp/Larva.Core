using Autofac;
using Larva.Core.Ioc;
using System;
using AutofacIContainer = Autofac.IContainer;
using AutofacContainerBuilder = Autofac.ContainerBuilder;
using AutofacContainerBuildOptions = Autofac.Builder.ContainerBuildOptions;

namespace Larva.Autofac
{
    /// <summary>
    /// Autofac容器
    /// </summary>
    public class AutofacContainer : AbstractContainer
    {
        internal AutofacContainer()
            : this(new AutofacContainerBuilder())
        { }

        internal AutofacContainer(AutofacContainerBuilder builder)
        {
            Builder = builder;
        }

        /// <summary>
        /// Autofac.IContainer（用于和其他组建间扩展）
        /// </summary>
        public AutofacIContainer Container { get; private set; }

        /// <summary>
        /// Autofac.ContainerBuilder（用于和其他组建间扩展）
        /// </summary>
        public ContainerBuilder Builder { get; private set; }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        public override void RegisterType(Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton)
        {
            var registrationBuilder = Builder.RegisterType(implementationType);
            if (serviceName != null)
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            if (life == LifetimeScope.Singleton)
            {
                registrationBuilder.SingleInstance();
            }
        }

        /// <summary>
        /// 注册实例
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="serviceName"></param>
        /// <typeparam name="TService"></typeparam>
        protected override void InnerRegisterInstance<TService>(TService instance, string serviceName)
        {
            var registrationBuilder = Builder.RegisterInstance(instance).As<TService>().SingleInstance();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="serviceName"></param>
        /// <param name="life"></param>
        protected override void InnerRegisterType(Type serviceType, Type implementationType, string serviceName = null, LifetimeScope life = LifetimeScope.Singleton)
        {
            var registrationBuilder = Builder.RegisterType(implementationType).As(serviceType);
            if (serviceName != null)
            {
                registrationBuilder.Named(serviceName, serviceType);
            }
            if (life == LifetimeScope.Singleton)
            {
                registrationBuilder.SingleInstance();
            }
        }

        /// <summary>
        /// 构建
        /// </summary>
        public override void Build()
        {
            Container = Builder.Build(AutofacContainerBuildOptions.ExcludeDefaultModules);
        }

        /// <summary>
        /// 是否已注册
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public override bool IsRegistered(Type serviceType, string serviceName = null)
        {
            return string.IsNullOrEmpty(serviceName)
                ? Container.IsRegistered(serviceType)
                : Container.IsRegisteredWithName(serviceName, serviceType);
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public override object Resolve(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        /// <summary>
        /// 解析已命名的
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public override object ResolveNamed(string serviceName, Type serviceType)
        {
            return Container.ResolveNamed(serviceName, serviceType);
        }
    }
}