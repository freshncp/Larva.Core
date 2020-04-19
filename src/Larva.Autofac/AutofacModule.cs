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
        /// 使用Autofac
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="canOverride"></param>
        /// <returns></returns>
        public static IModuleManager UseAutofac(this IModuleManager manager, bool canOverride = false)
        {
            return manager.UseIoc(new AutofacContainer(), canOverride);
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
            return manager.UseIoc(new AutofacContainer(containerBuilder), canOverride);
        }
    }
}