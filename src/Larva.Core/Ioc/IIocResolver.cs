using System;

namespace Larva.Core.Ioc
{
    /// <summary>
    /// IoC解析器
    /// </summary>
    public interface IIocResolver
    {
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
    }
}
