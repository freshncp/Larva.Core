namespace Larva.Core.Configuration
{
    /// <summary>
    /// 块配置
    /// </summary>
    public interface ISectionConfig
    {
        /// <summary>
        /// 块配置名
        /// </summary>
        string SectionName { get; }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Get(string key);
    }
}