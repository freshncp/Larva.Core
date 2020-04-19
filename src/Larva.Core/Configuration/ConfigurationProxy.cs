namespace Larva.Core.Configuration
{
    /// <summary>
    /// Configuration Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService]
    public sealed class ConfigurationProxy : IModuleProxy<IConfigurationManager>
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static IConfigurationManager Instance
        {
            get { return ModuleManager.Instance.GetConfigurationManager(); }
        }

        ModuleInstance<IConfigurationManager> IModuleProxy<IConfigurationManager>.GetModule()
        {
            return new ModuleInstance<IConfigurationManager>(ConfigurationModule.MODULE_NAME, Instance);
        }
    }
}