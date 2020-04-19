namespace Larva.Core
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public interface IModuleManager
    {
        /// <summary>
        /// 注册模块
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="value"></param>
        /// <param name="canOverride">是否覆盖</param>
        void Register(string moduleName, object value, bool canOverride);

        /// <summary>
        /// 是否已注册
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        bool IsRegistered(string moduleName);

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        object Get(string moduleName);
    }
}