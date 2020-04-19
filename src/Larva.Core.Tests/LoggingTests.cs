using System;
using Larva.Core.Logging;
using Xunit;

namespace Larva.Core.Tests
{
    public class LoggingTests
    {
        [Fact]
        public void TestConsoleLog()
        {
            ModuleManager.Instance.UseConsoleLog(canOverride: true);
            var logger = LoggingProxy.Instance.GetLogger(typeof(LoggingTests), disableCache: false);
            logger.Trace("just message");
            logger.Debug("just message");
            logger.Info("just message");
            logger.Warn("just message");
            logger.Error("just message");
            logger.Fatal("just message");
            try
            {
                throw new Exception("Test log ex");
            }
            catch (Exception ex)
            {
                logger.Trace("error occur", ex);
                logger.Debug("error occur", ex);
                logger.Info("error occur", ex);
                logger.Warn("error occur", ex);
                logger.Error("error occur", ex);
                logger.Fatal("error occur", ex);
            }
        }

        [Fact]
        public void TestFileLog()
        {
            ModuleManager.Instance.UseFileLog(canOverride: true);
            var logger = LoggingProxy.Instance.GetLogger(typeof(LoggingTests), disableCache: true);
            try
            {
                throw new Exception("Test log ex");
            }
            catch (Exception ex)
            {
                logger.Trace("error occur", ex);
                logger.Debug("error occur", ex);
                logger.Info("error occur", ex);
                logger.Warn("error occur", ex);
                logger.Error("error occur", ex);
                logger.Fatal("error occur", ex);
            }
        }
    }
}