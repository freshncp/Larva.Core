using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Larva.Core.Serialization.Binary.BinaryFormatterSerialization
{
    /// <summary>
    /// BinaryFormatter Serializer
    /// </summary>
    public class BinaryFormatterSerializer : IBinarySerializer
    {
        private BinaryFormatter _serializer = new BinaryFormatter();
        private static string _contentType = "application/octet-stream";

        /// <summary>
        /// 内容类型：MIME
        /// </summary>
        public string ContentType => _contentType;

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Serialize(object data)
        {
            byte[] buffer;
            using (var ms = new MemoryStream())
            {
                _serializer.Serialize(ms, data);
                ms.Position = 0;
                buffer = ms.GetBuffer();
            }
            return buffer;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] buffer)
        {
            object data;
            using (var ms = new MemoryStream())
            {
                ms.Write(buffer, 0, buffer.Length);
                ms.Position = 0;
                data = _serializer.Deserialize(ms);
                buffer = ms.GetBuffer();
            }
            return data;
        }
    }
}