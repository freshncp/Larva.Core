using System;
using System.IO;
using System.Reflection;

namespace Larva.Core.Logging.FileLog
{
    internal class FileLoggerFactory : AbstractLoggerFactory
    {
        private string _logDirectoryPath;
        private int _bufferSize;

        public FileLoggerFactory(string logPath = "", int bufferSize = 1024)
        {
            _logDirectoryPath = string.IsNullOrEmpty(logPath) ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs") : logPath;
            _bufferSize = bufferSize;
            if (!Directory.Exists(_logDirectoryPath))
            {
                Directory.CreateDirectory(_logDirectoryPath);
            }
        }

        protected override ILoggerAppender CreateLoggerAppender(Assembly repository)
        {
            return new FileLoggerAppender(repository, _logDirectoryPath, _bufferSize);
        }
    }
}