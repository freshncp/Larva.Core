namespace Larva.Core.Logging
{
    /// <summary>
    /// Logging模块
    /// </summary>
    public static class LoggingModule
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public const string MODULE_NAME = "Larva.Core.Logging";

        /// <summary>
        /// 使用日志工厂
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="loggerFactory">日志工厂</param>
        /// <param name="canOverride">是否允许覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseLogging(this IModuleManager manager, ILoggerFactory loggerFactory, bool canOverride = false)
        {
            manager.Register(MODULE_NAME, loggerFactory, canOverride);
            return manager;
        }

        /// <summary>
        /// 使用控制台日志
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseConsoleLog(this IModuleManager manager, bool canOverride = false)
        {
            manager.UseLogging(new ConsoleLog.ConsoleLoggerFactory(), canOverride);
            return manager;
        }

        /// <summary>
        /// 使用文件日志
        /// </summary>
        /// <param name="manager">模块管理器</param>
        /// <param name="logPath">日志目录</param>
        /// <param name="bufferSize">文件缓冲大小</param>
        /// <param name="canOverride">是否覆盖</param>
        /// <returns></returns>
        public static IModuleManager UseFileLog(this IModuleManager manager, string logPath = "", int bufferSize = 1024, bool canOverride = false)
        {
            manager.UseLogging(new FileLog.FileLoggerFactory(logPath, bufferSize), canOverride);
            return manager;
        }

        /// <summary>
        /// 获取日志工厂
        /// </summary>
        /// <param name="manager">配置管理器</param>
        /// <returns></returns>
        public static ILoggerFactory GetLoggerFactory(this IModuleManager manager)
        {
            return (ILoggerFactory)manager.Get(MODULE_NAME);
        }

        static LoggingModule()
        {
            Level = LogLevel.Trace;
        }

        /// <summary>
        /// 实例
        /// </summary>
        public static ILoggerFactory Instance
        {
            get
            {
                return ModuleManager.Instance.GetLoggerFactory();
            }
        }

        /// <summary>
        /// 日志级别（默认：Trace）
        /// </summary>
        public static LogLevel Level { get; set; }
    }
}