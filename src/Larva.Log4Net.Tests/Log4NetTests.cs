using Larva.Core;
using Larva.Core.Logging;
using System;
using Xunit;

namespace Larva.Log4Net.Tests
{
    public class Log4NetTests
    {
        [Fact]
        public void Test1()
        {
            ModuleManager.Instance.UseLog4Net(canOverride: true);
            var logger = LoggerFactory.GetLogger(typeof(Log4NetTests));
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
    }
}
