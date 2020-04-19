using System.Collections.Generic;
using System.Reflection;

namespace Larva.Core.Logging
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    public abstract class AbstractLoggerFactory : ILoggerFactory
    {
        private Dictionary<Assembly, ILoggerAppender> _cache = new Dictionary<Assembly, ILoggerAppender>();
        private object _locker = new object();

        /// <summary>
        /// 获取Logger追加器
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public ILoggerAppender GetLoggerAppender(Assembly repository)
        {
            if (_cache.ContainsKey(repository))
            {
                return _cache[repository];
            }
            else
            {
                lock (_locker)
                {
                    if (_cache.ContainsKey(repository))
                    {
                        return _cache[repository];
                    }
                    var loggerAppender = CreateLoggerAppender(repository);
                    _cache.Add(repository, loggerAppender);
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