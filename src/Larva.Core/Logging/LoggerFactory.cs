using System;
using System.Collections.Generic;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    public sealed class LoggerFactory
    {
        private static Dictionary<Type, ILogger> _cache = new Dictionary<Type, ILogger>();
        private static object _locker = new object();

        private LoggerFactory() { }

        static LoggerFactory()
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

        /// <summary>
        /// 获取Logger
        /// </summary>
        /// <param name="callerDeclaredType"></param>
        /// <param name="disableCache"></param>
        /// <returns></returns>
        public static ILogger GetLogger(Type callerDeclaredType, bool disableCache = false)
        {
            if (disableCache)
            {
                return new Internals.DefaultLogger(callerDeclaredType, Instance.GetLoggerAppender(callerDeclaredType.Assembly));
            }
            if (_cache.ContainsKey(callerDeclaredType))
            {
                return _cache[callerDeclaredType];
            }
            else
            {
                lock (_locker)
                {
                    if (_cache.ContainsKey(callerDeclaredType))
                    {
                        return _cache[callerDeclaredType];
                    }
                    var logger = new Internals.DefaultLogger(callerDeclaredType, Instance.GetLoggerAppender(callerDeclaredType.Assembly));
                    _cache.Add(callerDeclaredType, logger);
                    return logger;
                }
            }
        }
    }
}