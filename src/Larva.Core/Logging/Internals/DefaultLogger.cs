using System;

namespace Larva.Core.Logging.Internals
{
    internal class DefaultLogger : ILogger
    {
        private Type _callerDeclaredType;
        private ILoggerAppender _appender;

        public DefaultLogger(Type callerDeclaredType, ILoggerAppender appender)
        {
            _callerDeclaredType = callerDeclaredType;
            _appender = appender;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        private void Log(LogLevel logLevel, object message, Exception exception)
        {
            _appender.Log(_callerDeclaredType, logLevel, message, exception);
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            Log(LogLevel.Fatal, message, null);
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception)
        {
            Log(LogLevel.Fatal, message, exception);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            Log(LogLevel.Error, message, null);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
            Log(LogLevel.Error, message, exception);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            Log(LogLevel.Warn, message, null);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception)
        {
            Log(LogLevel.Warn, message, exception);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            Log(LogLevel.Info, message, null);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception)
        {
            Log(LogLevel.Info, message, exception);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            Log(LogLevel.Debug, message, null);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception)
        {
            Log(LogLevel.Debug, message, exception);
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message"></param>
        public void Trace(object message)
        {
            Log(LogLevel.Trace, message, null);
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Trace(object message, Exception exception)
        {
            Log(LogLevel.Trace, message, exception);
        }
    }
}