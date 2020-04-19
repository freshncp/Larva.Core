namespace Larva.Core.Ioc
{
    /// <summary>
    /// 生命期范围
    /// </summary>
    public enum LifetimeScope
    {
        /// <summary>
        /// 临时
        /// </summary>
        Transient = 0,

        /// <summary>
        /// 单例
        /// </summary>
        Singleton = 1
    }
}
