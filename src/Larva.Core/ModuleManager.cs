using System.Collections.Concurrent;

namespace Larva.Core
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public class ModuleManager : IModuleManager
    {
        private static readonly IModuleManager _instance = new ModuleManager();
        private ConcurrentDictionary<string, object> _configData = new ConcurrentDictionary<string, object>();

        private ModuleManager() { }

        /// <summary>
        /// 实例
        /// </summary>
        public static IModuleManager Instance
        {
            get { return _instance; }
        }

        void IModuleManager.Register(string moduleName, object value, bool canOverride)
        {
            if (canOverride)
            {
                _configData.AddOrUpdate(moduleName, value, (k, v) => value);
            }
            else
            {
                _configData.TryAdd(moduleName, value);
            }
        }

        object IModuleManager.Get(string moduleName)
        {
            object result = null;
            _configData.TryGetValue(moduleName, out result);
            return result;
        }

        bool IModuleManager.IsRegistered(string moduleName)
        {
            return _configData.ContainsKey(moduleName);
        }
    }
}