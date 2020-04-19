namespace Larva.Core.Configuration
{
    /// <summary>
    /// Configuration模块
    /// </summary>
    public static class ConfigurationModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Core.Configuration";

        /// <summary>
        /// 使用配置
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="configurationManager">配置管理器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseConfiguration(this IModuleManager manager, IConfigurationManager configurationManager, bool canOverride = false)
        {
            manager.Register(MODULE_NAME, configurationManager, canOverride);
            return manager;
        }

        /// <summary>
        /// 使用内存配置
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseMemoryConfiguration(this IModuleManager manager, bool canOverride = false)
        {
            return manager.UseConfiguration(MemoryConfig.MemoryConfigurationManager.Instance, canOverride);
        }

        /// <summary>
        /// 获取配置管理器
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <returns></returns>
        public static IConfigurationManager GetConfigurationManager(this IModuleManager manager)
        {
            return (IConfigurationManager)manager.Get(MODULE_NAME);
        }

        static ConfigurationModule() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static IConfigurationManager Instance
        {
            get { return ModuleManager.Instance.GetConfigurationManager(); }
        }
    }
}