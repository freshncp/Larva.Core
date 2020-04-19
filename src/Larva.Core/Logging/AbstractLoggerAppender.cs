using System;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志追加器
    /// </summary>
    public abstract class AbstractLoggerAppender : ILoggerAppender
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="callerDeclaredType"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Log(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception)
        {
            if ((byte)logLevel > (byte)LoggingProxy.Level) return;
            InternalLog(callerDeclaredType,logLevel, message, exception);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="callerDeclaredType"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        protected abstract void InternalLog(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception);        
    }
}