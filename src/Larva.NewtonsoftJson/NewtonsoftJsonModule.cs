using Larva.Core;
using Larva.Core.Serialization.Json;

namespace Larva.NewtonsoftJson
{
    /// <summary>
    /// NewtonsoftJson模块
    /// </summary>
    public static class NewtonsoftJsonModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.NewtonsoftJson";

        /// <summary>
        /// 使用NewtonsoftJson
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseNewtonsoftJson(this IModuleManager manager, bool canOverride = false)
        {
            var moduleInstance = new NewtonsoftJsonSerializer();
            manager.Register(MODULE_NAME, moduleInstance, canOverride);
            return manager.UseJsonSerialization(moduleInstance, canOverride);
        }

        static NewtonsoftJsonModule() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static NewtonsoftJsonSerializer Instance
        {
            get { return (NewtonsoftJsonSerializer)ModuleManager.Instance.Get(MODULE_NAME); }
        }
    }
}