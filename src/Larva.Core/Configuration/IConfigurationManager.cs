namespace Larva.Core.Configuration
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public interface IConfigurationManager : ISectionConfig
    {
        /// <summary>
        /// 获取块配置
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        ISectionConfig GetSection(string sectionName);
    }
}