using System;
using Larva.Core.Serialization.Json;

namespace Larva.NewtonsoftJson
{
    /// <summary>
    /// Newtonsoft.Json 序列号
    /// </summary>
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        private static string _contentType = "text/json";

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
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None);
            return System.Text.Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] buffer)
        {
            var str = System.Text.Encoding.UTF8.GetString(buffer);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(str, type);
        }
    }
}