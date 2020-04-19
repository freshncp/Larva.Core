namespace Larva.Core.Serialization.Json
{
    /// <summary>
    /// Json序列化模块
    /// </summary>
    public static class JsonSerializationModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Core.Serialization.Text";

        /// <summary>
        /// 使用Json序列化
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="serializer">文本序列化器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseJsonSerialization(this IModuleManager manager, IJsonSerializer serializer, bool canOverride = false)
        {
            manager.Register(MODULE_NAME, serializer, canOverride);
            return manager;
        }
        
        /// <summary>
        /// 获取Json序列化
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <returns></returns>
        public static IJsonSerializer GetJsonSerializer(this IModuleManager manager)
        {
            return (IJsonSerializer)manager.Get(MODULE_NAME);
        }
    }
}