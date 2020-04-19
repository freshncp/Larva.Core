using System.Linq;
using System.Reflection;

namespace Larva.Core.Ioc
{
    /// <summary>
    /// IoC模块
    /// </summary>
    public static class IocModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Core.Ioc";

        /// <summary>
        /// 使用IoC
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="iocContainer">容器对象</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseIoc(this IModuleManager manager, IContainer iocContainer, bool canOverride = false)
        {
            iocContainer.Register<IIocResolver, Internals.DefaultIocResolver>();
            manager.Register(MODULE_NAME, iocContainer, canOverride);
            return manager;
        }

        /// <summary>
        /// 获取IoC容器
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <returns></returns>
        public static IContainer GetIocContainer(this IModuleManager manager)
        {
            return (IContainer)manager.Get(MODULE_NAME);
        }

        static IocModule() { }

        /// <summary>
        /// 获取实例
        /// </summary>
        public static IContainer Instance
        {
            get
            {
                return ModuleManager.Instance.GetIocContainer();
            }
        }

        /// <summary>
        /// 按程序集注册
        /// </summary>
        /// <param name="assemblyToRegister"></param>
        public static void RegisterByAssembly(Assembly assemblyToRegister)
        {
            var instance = Instance;
            if (assemblyToRegister == null)
            {
                throw new System.ArgumentNullException("assemblyToRegister");
            }
            foreach (var implType in assemblyToRegister.GetTypes())
            {
                var serviceTypeConfig = implType.GetCustomAttribute<IocServiceAttribute>();
                if (serviceTypeConfig != null)
                {
                    var interfaces = implType.GetInterfaces();
                    if (interfaces == null || interfaces.Length == 0)
                    {
                        // 无接口，直接注册类型
                        instance.RegisterType(implType, life: serviceTypeConfig.Scope);
                        continue;
                    }
                    var serviceTypes = serviceTypeConfig.ServiceTypes;
                    if (serviceTypes != null && serviceTypes.Length > 0)
                    {
                        // 配置的服务类型列表和接口列表取交集
                        serviceTypes = serviceTypes.Intersect(interfaces).ToArray();
                    }
                    else
                    {
                        serviceTypes = interfaces;
                    }
                    foreach (var serviceType in serviceTypes)
                    {
                        instance.RegisterType(serviceType, implType, serviceName: serviceTypeConfig.ServiceName, life: serviceTypeConfig.Scope);
                    }
                }
            }
        }
    }
}