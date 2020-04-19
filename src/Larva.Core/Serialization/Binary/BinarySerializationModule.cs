namespace Larva.Core.Serialization.Binary
{
    /// <summary>
    /// 二进制序列化模块
    /// </summary>
    public static class BinarySerializationModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Core.Serialization.Binary";

        /// <summary>
        /// 使用二进制序列化
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="serializer">二进制序列化器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseBinarySerialization(this IModuleManager manager, IBinarySerializer serializer, bool canOverride = false)
        {
            manager.Register(MODULE_NAME, serializer, canOverride);
            return manager;
        }

        /// <summary>
        /// 使用BinaryFormatter
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseBinaryFormatter(this IModuleManager manager, bool canOverride = false)
        {
            return manager.UseBinarySerialization(new BinaryFormatterSerialization.BinaryFormatterSerializer(), canOverride);
        }

        /// <summary>
        /// 获取二进制序列化
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <returns></returns>
        public static IBinarySerializer GetBinarySerializer(this IModuleManager manager)
        {
            return (IBinarySerializer)manager.Get(MODULE_NAME);
        }
    }
}