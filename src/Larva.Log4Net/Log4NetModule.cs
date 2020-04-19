using Larva.Core;
using Larva.Core.Logging;

namespace Larva.Log4Net
{
    /// <summary>
    /// Log4Net模块
    /// </summary>
    public static class Log4NetModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Log4Net";

        /// <summary>
        /// 使用Log4Net
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="configFilePath">配置文件路径</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseLog4Net(this IModuleManager manager, string configFilePath = "", bool canOverride = false)
        {
            var moduleInstance = new Log4NetLoggerFactory(configFilePath);
            manager.Register(MODULE_NAME, moduleInstance, canOverride);
            return manager.UseLogging(moduleInstance, canOverride);
        }
    }
}