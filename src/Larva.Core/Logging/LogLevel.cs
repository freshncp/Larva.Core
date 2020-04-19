namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel : byte
    {
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal = 0,
        
        /// <summary>
        /// 错误
        /// </summary>
        Error = 1,
        
        /// <summary>
        /// 警告
        /// </summary>
        Warn = 2,
        
        /// <summary>
        /// 信息
        /// </summary>
        Info = 3,
        
        /// <summary>
        /// 调试
        /// </summary>
        Debug = 4,
        
        /// <summary>
        /// 跟踪
        /// </summary>
        Trace = 5
    }
}