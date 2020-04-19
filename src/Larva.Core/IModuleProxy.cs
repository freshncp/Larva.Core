namespace Larva.Core
{
    /// <summary>
    /// 模块代理
    /// </summary>
    /// <typeparam name="T">抽象接口</typeparam>
    public interface IModuleProxy<T> where T : class
    {
        /// <summary>
        /// 获取模块实例
        /// </summary>
        /// <returns></returns>
        ModuleInstance<T> GetModule();
    }
}