using System;

namespace Larva.Core
{
    /// <summary>
    /// 模块未找到异常
    /// </summary>
    public class ModuleNotFoundException : Exception
    {
        /// <summary>
        /// 模块未找到异常
        /// </summary>
        public ModuleNotFoundException()
            : base() { }

        /// <summary>
        /// 模块未找到异常
        /// </summary>
        /// <param name="message"></param>
        public ModuleNotFoundException(string message)
            : base(message) { }

        /// <summary>
        /// 模块未找到异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ModuleNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}