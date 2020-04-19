namespace Larva.Core.Logging
{
    /// <summary>
    /// Logging Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService]
    public sealed class LoggingProxy : IModuleProxy<ILoggerFactory>
    {
        static LoggingProxy()
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

        ModuleInstance<ILoggerFactory> IModuleProxy<ILoggerFactory>.GetModule()
        {
            return new ModuleInstance<ILoggerFactory>(LoggingModule.MODULE_NAME, Instance);
        }

        /// <summary>
        /// 日志级别（默认：Trace）
        /// </summary>
        public static LogLevel Level { get; set; }
    }
}