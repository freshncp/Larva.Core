using System;
using System.Reflection;

namespace Larva.Core.Logging.ConsoleLog
{
    internal class ConsoleLoggerFactory : AbstractLoggerFactory
    {
        protected override ILoggerAppender CreateLoggerAppender(Assembly repository)
        {
            return new ConsoleLoggerAppender();
        }
    }
}