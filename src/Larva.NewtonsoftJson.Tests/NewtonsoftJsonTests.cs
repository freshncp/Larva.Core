using Larva.Core;
using Larva.Core.Serialization.Json;
using Xunit;

namespace Larva.NewtonsoftJson.Tests
{
    public class NewtonsoftJsonTests
    {
        [Fact]
        public void TestSerializeAndDeserialize()
        {
            ModuleManager.Instance.UseNewtonsoftJson(true);
            var text1 = "this is a text";
            var buffer = JsonSerializationModule.Instance.Serialize(text1);
            var text2 = JsonSerializationModule.Instance.Deserialize(typeof(string), buffer);
            Assert.Equal(text1, text2);
        }
    }
}
