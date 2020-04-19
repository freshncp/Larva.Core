using System;

namespace Larva.Core.Serialization
{
    /// <summary>
    /// 序列号接口
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 内容类型：MIME
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// 序列号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] Serialize(object data);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        object Deserialize(Type type, byte[] data);
    }
}