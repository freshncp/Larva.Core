namespace Larva.Core.Serialization.Binary
{
    /// <summary>
    /// BinarySerialization Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService]
    public sealed class BinarySerializationProxy : IModuleProxy<IBinarySerializer>
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static IBinarySerializer Instance
        {
            get { return ModuleManager.Instance.GetBinarySerializer(); }
        }

        ModuleInstance<IBinarySerializer> IModuleProxy<IBinarySerializer>.GetModule()
        {
            return new ModuleInstance<IBinarySerializer>(BinarySerializationModule.MODULE_NAME, Instance);
        }
    }
}