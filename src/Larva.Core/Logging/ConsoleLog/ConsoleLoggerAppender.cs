using System;

namespace Larva.Core.Logging.ConsoleLog
{
    internal class ConsoleLoggerAppender : AbstractLoggerAppender
    {
        protected override void InternalLog(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception)
        {
            if (exception == null)
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {logLevel.ToString().ToUpper()} [{callerDeclaredType.Name}] - {message}");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {logLevel.ToString().ToUpper()} [{callerDeclaredType.Name}] - {message}\n{exception.GetType().FullName}: {exception.Message}\n{exception.StackTrace}");
            }
        }
    }
}