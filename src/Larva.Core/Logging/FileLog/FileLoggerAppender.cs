using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Larva.Core.Logging.FileLog
{
    internal class FileLoggerAppender : AbstractLoggerAppender
    {
        private string _logFilePathPrefix;
        private int _bufferSize;
        private string _lastDateString;
        private StreamWriter _streamWriter;
        private Timer _timer;

        internal FileLoggerAppender(Assembly repository, string logDirectoryPath, int bufferSize)
        {
            _logFilePathPrefix = Path.Combine(logDirectoryPath, $"{repository.GetName().Name}");
            _bufferSize = bufferSize;
            _lastDateString = DateTime.Today.ToString("yyyy-MM-dd");
            var fs = File.Open($"{_logFilePathPrefix}_{_lastDateString}.log", FileMode.Append, FileAccess.Write, FileShare.Read);
            if (_bufferSize > 0)
            {
                _streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8, _bufferSize);
            }
            else
            {
                _streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8);
            }
            _streamWriter.AutoFlush = true;

            _timer = new Timer(SwitchLogFile);
            _timer.Change(1000, 1000);
        }

        protected override void InternalLog(Type callerDeclaredType, LogLevel logLevel, object message, Exception exception)
        {
            try
            {
                if (exception == null)
                {
                    _streamWriter.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {logLevel.ToString().ToUpper()} [{callerDeclaredType.Name}] - {message}");
                }
                else
                {
                    _streamWriter.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {logLevel.ToString().ToUpper()} [{callerDeclaredType.Name}] - {message}\n{exception.GetType().FullName}: {exception.Message}\n{exception.StackTrace}");
                }
            }
            catch { }
        }

        private void SwitchLogFile(object state)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                var currentDateString = DateTime.Today.ToString("yyyy-MM-dd");
                var lastDateString = _lastDateString;
                if (currentDateString != lastDateString)
                {
                    var originStreamWriter = _streamWriter;
                    var fs = File.Open($"{_logFilePathPrefix}_{currentDateString}.log", FileMode.Append, FileAccess.Write, FileShare.Read);
                    if (_bufferSize > 0)
                    {
                        _streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8, _bufferSize);
                    }
                    else
                    {
                        _streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    }
                    _streamWriter.AutoFlush = true;
                    Thread.Sleep(100);// 等待使用源StreamWriter写完
                    originStreamWriter.Flush();
                    originStreamWriter.Close();
                    _lastDateString = currentDateString;
                    Console.WriteLine($"FileLog switch log file: lastDateString={lastDateString}, currentDateString={currentDateString}");
                }
                else
                {
                    if (!File.Exists($"{_logFilePathPrefix}_{lastDateString}.log"))
                    {
                        var originStreamWriter = _streamWriter;
                        var fs = File.Open($"{_logFilePathPrefix}_{lastDateString}.log", FileMode.Append, FileAccess.Write, FileShare.Read);
                        if (_bufferSize > 0)
                        {
                            _streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8, _bufferSize);
                        }
                        else
                        {
                            _streamWriter = new StreamWriter(fs, System.Text.Encoding.UTF8);
                        }
                        _streamWriter.AutoFlush = true;
                        originStreamWriter.Close();
                        Console.WriteLine($"FileLog rebuild log file: lastDateString={lastDateString}");
                    }
                }
            }
            catch { }
            _timer.Change(1000, 1000);
        }
    }
}