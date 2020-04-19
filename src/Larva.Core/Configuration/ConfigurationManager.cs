namespace Larva.Core.Configuration
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public sealed class ConfigurationManager
    {
        private ConfigurationManager() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static IConfigurationManager Instance
        {
            get { return ModuleManager.Instance.GetConfigurationManager(); }
        }
    }
}