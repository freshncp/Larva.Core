using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Larva.Core.Configuration.MemoryConfig
{
    /// <summary>
    /// 块配置
    /// </summary>
    public class MemorySectionConfig : ISectionConfig
    {
        private ConcurrentDictionary<string, Tuple<object, bool>> _configData = new ConcurrentDictionary<string, Tuple<object, bool>>();

        /// <summary>
        /// 块配置
        /// </summary>
        /// <param name="sectionName"></param>
        public MemorySectionConfig(string sectionName)
        {
            SectionName = sectionName;
        }

        /// <summary>
        /// 块配置
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="canOverride"></param>
        /// <param name="dict"></param>
        public MemorySectionConfig(string sectionName, bool canOverride, IDictionary<string, object> dict)
        {
            SectionName = sectionName;
            if (dict != null)
            {
                foreach (var item in dict)
                {
                    _configData.TryAdd(item.Key, new Tuple<object, bool>(item.Value, canOverride));
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
            _configData.TryGetValue(key, out Tuple<object, bool> result);
            return result == null ? null : result.Item1;
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="canOverride"></param>
        public void Set(string key, object value, bool canOverride)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            _configData.AddOrUpdate(key, new Tuple<object, bool>(value, canOverride), (k, v) => v.Item2 ? new Tuple<object, bool>(value, canOverride) : v);
        }
    }
}