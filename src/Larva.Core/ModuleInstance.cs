namespace Larva.Core
{
    /// <summary>
    /// 模块实例
    /// </summary>
    /// <typeparam name="T">抽象接口</typeparam>
    public class ModuleInstance<T> where T : class
    {
        /// <summary>
        /// 模块实例
        /// </summary>
        /// <param name="moduleName">模块名</param>
        /// <param name="instance">抽象接口实例</param>
        public ModuleInstance(string moduleName, T instance)
        {
            ModuleName = moduleName;
            Instance = instance;
        }

        /// <summary>
        /// 抽象接口实例
        /// </summary>
        public T Instance { get; private set; }

        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; private set; }
    }
}