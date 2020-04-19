using System.Linq;
using System.Reflection;

namespace Larva.Core.Ioc
{
    /// <summary>
    /// IoC Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService]
    public sealed class IocProxy : IModuleProxy<IContainer>
    {
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

        ModuleInstance<IContainer> IModuleProxy<IContainer>.GetModule()
        {
            return new ModuleInstance<IContainer>(IocModule.MODULE_NAME, Instance);
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