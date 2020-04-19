using System;
using System.Collections.Generic;
using System.Reflection;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    public abstract class AbstractLoggerFactory : ILoggerFactory
    {
        private Dictionary<Assembly, ILoggerAppender> _loggerAppenderCache = new Dictionary<Assembly, ILoggerAppender>();
        private object _loggerAppenderLocker = new object();
        private Dictionary<Type, ILogger> _loggerCache = new Dictionary<Type, ILogger>();
        private object _loggerLocker = new object();

        /// <summary>
        /// 获取Logger
        /// </summary>
        /// <param name="callerDeclaredType"></param>
        /// <param name="disableCache"></param>
        /// <returns></returns>
        public ILogger GetLogger(Type callerDeclaredType, bool disableCache = false)
        {
            if (disableCache)
            {
                return new Internals.DefaultLogger(callerDeclaredType, GetLoggerAppender(callerDeclaredType.Assembly));
            }
            if (_loggerCache.ContainsKey(callerDeclaredType))
            {
                return _loggerCache[callerDeclaredType];
            }
            else
            {
                lock (_loggerLocker)
                {
                    if (_loggerCache.ContainsKey(callerDeclaredType))
                    {
                        return _loggerCache[callerDeclaredType];
                    }
                    var logger = new Internals.DefaultLogger(callerDeclaredType, GetLoggerAppender(callerDeclaredType.Assembly));
                    _loggerCache.Add(callerDeclaredType, logger);
                    return logger;
                }
            }
        }

        /// <summary>
        /// 获取Logger追加器
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public ILoggerAppender GetLoggerAppender(Assembly repository)
        {
            if (_loggerAppenderCache.ContainsKey(repository))
            {
                return _loggerAppenderCache[repository];
            }
            else
            {
                lock (_loggerAppenderLocker)
                {
                    if (_loggerAppenderCache.ContainsKey(repository))
                    {
                        return _loggerAppenderCache[repository];
                    }
                    var loggerAppender = CreateLoggerAppender(repository);
                    _loggerAppenderCache.Add(repository, loggerAppender);
                    return loggerAppender;
                }
            }
        }

        /// <summary>
        /// 创建Logger追加器
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        protected abstract ILoggerAppender CreateLoggerAppender(Assembly repository);
    }
}