namespace Larva.Core.Serialization.Json
{
    /// <summary>
    /// JsonSerialization Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService]
    public sealed class JsonSerializationProxy : IModuleProxy<IJsonSerializer>
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static IJsonSerializer Instance
        {
            get { return ModuleManager.Instance.GetJsonSerializer(); }
        }

        ModuleInstance<IJsonSerializer> IModuleProxy<IJsonSerializer>.GetModule()
        {
            return new ModuleInstance<IJsonSerializer>(JsonSerializationModule.MODULE_NAME, Instance);
        }
    }
}