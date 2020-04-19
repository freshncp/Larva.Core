using System;
using System.Reflection;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// 获取Logger
        /// </summary>
        /// <param name="callerDeclaredType"></param>
        /// <param name="disableCache"></param>
        /// <returns></returns>
        ILogger GetLogger(Type callerDeclaredType, bool disableCache = false);

        /// <summary>
        /// 获取Logger追加器
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        ILoggerAppender GetLoggerAppender(Assembly repository);
    }
}