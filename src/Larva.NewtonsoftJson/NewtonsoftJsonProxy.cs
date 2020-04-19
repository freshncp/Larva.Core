using Larva.Core;
using Larva.Core.Serialization.Json;

namespace Larva.NewtonsoftJson
{
    /// <summary>
    /// NewtonsoftJson Proxy
    /// </summary>
    [Larva.Core.Ioc.IocService(ServiceName = NewtonsoftJsonModule.MODULE_NAME)]
    public sealed class NewtonsoftJsonProxy : IModuleProxy<IJsonSerializer>
    {
        ModuleInstance<IJsonSerializer> IModuleProxy<IJsonSerializer>.GetModule()
        {
            return new ModuleInstance<IJsonSerializer>(NewtonsoftJsonModule.MODULE_NAME, JsonSerializationProxy.Instance);
        }
    }
}