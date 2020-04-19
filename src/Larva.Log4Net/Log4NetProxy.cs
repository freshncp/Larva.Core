using Larva.Core;
using Larva.Core.Logging;

namespace Larva.Log4Net
{
    /// <summary>
    /// Log4Net Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService(ServiceName = Log4NetModule.MODULE_NAME)]
    public sealed class Log4NetProxy : IModuleProxy<ILoggerFactory>
    {
        ModuleInstance<ILoggerFactory> IModuleProxy<ILoggerFactory>.GetModule()
        {
            return new ModuleInstance<ILoggerFactory>(Log4NetModule.MODULE_NAME, LoggingProxy.Instance);
        }
    }
}