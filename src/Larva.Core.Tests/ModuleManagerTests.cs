using Xunit;

namespace Larva.Core.Tests
{
    public class ModuleManagerTests
    {
        [Fact]
        public void TestRegisterWithNotOverride()
        {
            ModuleManager.Instance.Register("key1", "value1", true);
            ModuleManager.Instance.Register("key1", "value2", false);

            Assert.Equal("value1", ModuleManager.Instance.Get("key1"));
        }

        [Fact]
        public void TestRegisterWithOverride()
        {
            ModuleManager.Instance.Register("key1", "value1", true);
            ModuleManager.Instance.Register("key1", "value2", true);

            Assert.Equal("value2", ModuleManager.Instance.Get("key1"));
        }
    }
}