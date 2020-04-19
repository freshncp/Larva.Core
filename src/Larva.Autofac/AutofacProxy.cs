using Larva.Core;
using Larva.Core.Ioc;

namespace Larva.Autofac
{
    /// <summary>
    /// Autofac Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService(ServiceName = AutofacModule.MODULE_NAME)]
    public sealed class AutofacProxy : IModuleProxy<IContainer>
    {
        ModuleInstance<IContainer> IModuleProxy<IContainer>.GetModule()
        {
            return new ModuleInstance<IContainer>(AutofacModule.MODULE_NAME, IocProxy.Instance);
        }
    }
}