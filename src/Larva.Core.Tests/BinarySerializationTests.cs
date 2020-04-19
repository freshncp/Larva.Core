using Larva.Core.Serialization.Binary;
using Xunit;

namespace Larva.Core.Tests
{
    public class BinarySerializationTests
    {
        [Fact]
        public void TestBinaryFormatter()
        {
            ModuleManager.Instance.UseBinaryFormatter(true);
            var text1 = "This is a text.";
            var buffer = BinarySerializationProxy.Instance.Serialize(text1);
            var text2 = BinarySerializationProxy.Instance.Deserialize(typeof(string), buffer);
            Assert.Equal(text1, text2);
        }
    }
}