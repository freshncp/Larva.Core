using System;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志追加器
    /// </summary>
    public interface ILoggerAppender
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="callerDeclaredType"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Log(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception);
    }
}