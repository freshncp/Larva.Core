using System;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message);

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        void Error(object message);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(object message, Exception exception);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        void Info(object message);

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(object message, Exception exception);

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        void Debug(object message);

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message"></param>
        void Trace(object message);

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Trace(object message, Exception exception);
    }
}