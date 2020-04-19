using System;
using System.IO;
using System.Reflection;
using Larva.Core.Logging;

namespace Larva.Log4Net
{
    /// <summary>
    /// Log4Net日志工厂
    /// </summary>
    public class Log4NetLoggerFactory : AbstractLoggerFactory
    {
        private string _configFilePath;

        internal Log4NetLoggerFactory(string configFilePath)
        {
            _configFilePath = string.IsNullOrEmpty(configFilePath) ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config") : configFilePath;
        }

        /// <summary>
        /// 创建Logger
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        protected override ILoggerAppender CreateLoggerAppender(Assembly repository)
        {
            var logRepository = log4net.LogManager.CreateRepository(repository.GetName().Name);
            var fi = new FileInfo(_configFilePath);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(logRepository, fi);
            return new Log4NetLoggerAppender(logRepository);
        }
    }
}
