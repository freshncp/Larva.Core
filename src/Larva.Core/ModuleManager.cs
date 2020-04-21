using System;
using System.Collections.Concurrent;

namespace Larva.Core
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public class ModuleManager : IModuleManager
    {
        private static readonly IModuleManager _instance = new ModuleManager();
        private ConcurrentDictionary<string, Tuple<object, bool>> _configData = new ConcurrentDictionary<string, Tuple<object, bool>>();

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
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new ArgumentNullException(nameof(moduleName));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _configData.AddOrUpdate(moduleName, new Tuple<object, bool>(value, canOverride), (m, v) => v.Item2 ? new Tuple<object, bool>(value, canOverride) : v);
        }

        object IModuleManager.Get(string moduleName)
        {
            _configData.TryGetValue(moduleName, out Tuple<object, bool> result);
            if (result == null)
            {
                throw new ModuleNotFoundException($"Module {moduleName} not found. Please use ModuleManager to register.");
            }
            return result.Item1;
        }

        bool IModuleManager.IsRegistered(string moduleName)
        {
            return _configData.ContainsKey(moduleName);
        }
    }
}