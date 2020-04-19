namespace Larva.Core.Serialization.Json
{
    /// <summary>
    /// Json序列化
    /// </summary>
    public sealed class JsonSerializer
    {
        private JsonSerializer() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static IJsonSerializer Instance
        {
            get { return ModuleManager.Instance.GetJsonSerializer(); }
        }
    }
}