using System;
using System.Collections.Generic;
using Larva.Core.Logging;

namespace Larva.Log4Net
{
    internal class Log4NetLoggerAppender : AbstractLoggerAppender
    {
        private log4net.Repository.ILoggerRepository _loggerRepository;

        private static Dictionary<LogLevel, log4net.Core.Level> _logLevelMapping;

        static Log4NetLoggerAppender()
        {
            _logLevelMapping = new Dictionary<LogLevel, log4net.Core.Level>
            {
                { LogLevel.Fatal, log4net.Core.Level.Fatal },
                { LogLevel.Error, log4net.Core.Level.Error },
                { LogLevel.Warn, log4net.Core.Level.Warn },
                { LogLevel.Info, log4net.Core.Level.Info },
                { LogLevel.Debug, log4net.Core.Level.Debug },
                { LogLevel.Trace, log4net.Core.Level.Trace }
            };
        }

        internal Log4NetLoggerAppender(log4net.Repository.ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        protected override void InternalLog(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception)
        {   
            _loggerRepository.GetLogger(callerDeclaredType.Name).Log(callerDeclaredType, _logLevelMapping[logLevel], message, exception);
        }
    }
}