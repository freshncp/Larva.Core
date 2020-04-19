namespace Larva.Core.Serialization.Binary
{
    /// <summary>
    /// 二进制序列化
    /// </summary>
    public sealed class BinarySerializer
    {
        private BinarySerializer() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static IBinarySerializer Instance
        {
            get { return ModuleManager.Instance.GetBinarySerializer(); }
        }
    }
}