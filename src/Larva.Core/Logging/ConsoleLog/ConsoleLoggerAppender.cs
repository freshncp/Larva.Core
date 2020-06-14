using System;
using System.IO;

namespace Larva.Core.Logging.ConsoleLog
{
    internal class ConsoleLoggerAppender : AbstractLoggerAppender
    {
        private object _locker = new object();

        protected override void InternalLog(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception)
        {
            lock (_locker)
            {
                switch (logLevel)
                {
                    case LogLevel.Trace:
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case LogLevel.Info:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case LogLevel.Warn:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogLevel.Error:
                    case LogLevel.Fatal:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }
                var logContent = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {logLevel.ToString().ToUpper()} [{callerDeclaredType.Name}] - {message}";
                if (exception != null)
                {
                    logContent = $"{logContent}\n{exception.GetType().FullName}: {exception.Message}\n{exception.StackTrace}";
                }
                Console.WriteLine(logContent);
                if (logLevel == LogLevel.Error || logLevel == LogLevel.Fatal)
                {
                    using (var sw = new StreamWriter(Console.OpenStandardError()))
                    {
                        sw.WriteLine(logContent);
                        sw.Flush();
                    }
                }
                Console.ResetColor();
            }
        }
    }
}