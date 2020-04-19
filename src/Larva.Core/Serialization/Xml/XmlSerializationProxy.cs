namespace Larva.Core.Serialization.Xml
{
    /// <summary>
    /// XmlSerialization Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService]
    public sealed class XmlSerializationProxy : IModuleProxy<IXmlSerializer>
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static IXmlSerializer Instance
        {
            get { return ModuleManager.Instance.GetXmlSerializer(); }
        }

        ModuleInstance<IXmlSerializer> IModuleProxy<IXmlSerializer>.GetModule()
        {
            return new ModuleInstance<IXmlSerializer>(XmlSerializationModule.MODULE_NAME, Instance);
        }
    }
}