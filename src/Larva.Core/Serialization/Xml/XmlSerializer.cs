namespace Larva.Core.Serialization.Xml
{
    /// <summary>
    /// Xml序列化
    /// </summary>
    public sealed class XmlSerializer
    {
        private XmlSerializer() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static IXmlSerializer Instance
        {
            get { return ModuleManager.Instance.GetXmlSerializer(); }
        }
    }
}