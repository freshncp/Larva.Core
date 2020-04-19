using System.Collections.Concurrent;

namespace Larva.Core.Configuration.MemoryConfig
{
    /// <summary>
    /// 内存配置管理器
    /// </summary>
    public sealed class MemoryConfigurationManager : IConfigurationManager
    {
        private ConcurrentDictionary<string, MemorySectionConfig> _configData = new ConcurrentDictionary<string, MemorySectionConfig>();
        private static readonly MemoryConfigurationManager _instance = new MemoryConfigurationManager();

        private MemoryConfigurationManager()
        {
            _configData.TryAdd(SectionName, new MemorySectionConfig(SectionName));
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
            return section == null ? null : section.Get(key);
        }

        /// <summary>
        /// 获取块配置
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public ISectionConfig GetSection(string sectionName)
        {
            _configData.TryGetValue(sectionName, out MemorySectionConfig result);
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
            _configData[SectionName].Set(key, value, canOverride);
        }

        /// <summary>
        /// 设置块配置
        /// </summary>
        /// <param name="section"></param>
        /// <param name="canOverride"></param>
        public void SetSection(MemorySectionConfig section, bool canOverride)
        {
            if (section == null) return;
            if (canOverride)
            {
                _configData.AddOrUpdate(section.SectionName, section, (sectionName, originSection) => section);
            }
            else
            {
                _configData.TryAdd(section.SectionName, section);
            }
        }
    }
}