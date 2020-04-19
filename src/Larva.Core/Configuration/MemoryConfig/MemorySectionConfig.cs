using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Larva.Core.Configuration.MemoryConfig
{
    /// <summary>
    /// 块配置
    /// </summary>
    public class MemorySectionConfig : ISectionConfig
    {
        private ConcurrentDictionary<string, object> _configData = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// 块配置
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="dict"></param>
        public MemorySectionConfig(string sectionName, IDictionary<string, object> dict = null)
        {
            SectionName = sectionName;
            if (dict != null)
            {
                foreach (var item in dict)
                {
                    _configData.TryAdd(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// 块配置名
        /// </summary>
        public string SectionName { get; private set; }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            object result = null;
            _configData.TryGetValue(key, out result);
            return result;
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="canOverride"></param>
        public void Set(string key, object value, bool canOverride)
        {
            if (canOverride)
            {
                _configData.AddOrUpdate(key, value, (k, v) => value);
            }
            else
            {
                _configData.TryAdd(key, value);
            }
        }

    }
}