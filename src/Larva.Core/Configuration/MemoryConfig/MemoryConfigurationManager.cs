using System;
using System.Collections.Concurrent;

namespace Larva.Core.Configuration.MemoryConfig
{
    /// <summary>
    /// 内存配置管理器
    /// </summary>
    public sealed class MemoryConfigurationManager : IConfigurationManager
    {
        private ConcurrentDictionary<string, Tuple<MemorySectionConfig, bool>> _configData = new ConcurrentDictionary<string, Tuple<MemorySectionConfig, bool>>();
        private static readonly MemoryConfigurationManager _instance = new MemoryConfigurationManager();

        private MemoryConfigurationManager()
        {
            _configData.TryAdd(SectionName, new Tuple<MemorySectionConfig, bool>(new MemorySectionConfig(SectionName), false));
        }

        /// <summary>
        /// 实例
        /// </summary>
        public static MemoryConfigurationManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 块配置名
        /// </summary>
        public string SectionName { get { return string.Empty; } }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            var section = _configData[SectionName];
            return section == null ? null : section.Item1.Get(key);
        }

        /// <summary>
        /// 获取块配置
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public ISectionConfig GetSection(string sectionName)
        {
            _configData.TryGetValue(sectionName, out Tuple<MemorySectionConfig, bool> result);
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
            _configData[SectionName].Item1.Set(key, value, canOverride);
        }

        /// <summary>
        /// 设置块配置
        /// </summary>
        /// <param name="section"></param>
        /// <param name="canOverride"></param>
        public void SetSection(MemorySectionConfig section, bool canOverride)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }
            if (string.IsNullOrEmpty(section.SectionName))
            {
                throw new ArgumentException("section.SectionName must not empty.", nameof(section));
            }
            var addValue = new Tuple<MemorySectionConfig, bool>(section, canOverride);
            _configData.AddOrUpdate(section.SectionName, addValue, (k, v) => v.Item2 ? addValue : v);
        }
    }
}