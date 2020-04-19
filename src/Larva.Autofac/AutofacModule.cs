using Larva.Core;
using Larva.Core.Ioc;
using AutofacContainerBuilder = Autofac.ContainerBuilder;

namespace Larva.Autofac
{
    /// <summary>
    /// Autofac模块
    /// </summary>
    public static class AutofacModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Autofac";

        /// <summary>
        /// 使用Autofac
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="canOverride"></param>
        /// <returns></returns>
        public static IModuleManager UseAutofac(this IModuleManager manager, bool canOverride = false)
        {
            var moduleInstance = new AutofacContainer();
            manager.Register(MODULE_NAME, moduleInstance, canOverride);
            return manager.UseIoc(moduleInstance, canOverride);
        }

        /// <summary>
        /// 使用Autofac
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="containerBuilder">Autofac的ContainerBuilder</param>
        /// <param name="canOverride"></param>
        /// <returns></returns>
        public static IModuleManager UseAutofac(this IModuleManager manager, AutofacContainerBuilder containerBuilder, bool canOverride = false)
        {
            var moduleInstance = new AutofacContainer(containerBuilder);
            manager.Register(MODULE_NAME, moduleInstance, canOverride);
            return manager.UseIoc(moduleInstance, canOverride);
        }

        static AutofacModule() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static AutofacContainer Instance
        {
            get { return (AutofacContainer)ModuleManager.Instance.Get(MODULE_NAME); }
        }
    }
}