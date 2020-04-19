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
    }
}