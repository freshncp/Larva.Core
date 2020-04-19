using System;

namespace Larva.Core.Ioc
{
    /// <summary>
    /// IoC服务
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class IocServiceAttribute : Attribute
    {
        /// <summary>
        /// IoC服务（默认单例；有接口的，注册接口；无接口的，则注册当前类）
        /// </summary>
        public IocServiceAttribute()
        {
            Scope = LifetimeScope.Singleton;
            ServiceTypes = null;
        }

        /// <summary>
        /// 生命期范围
        /// </summary>
        public LifetimeScope Scope { get; set; }

        /// <summary>
        /// 服务类型（接口）列表
        /// </summary>
        public Type[] ServiceTypes { get; set; }
    }
}
