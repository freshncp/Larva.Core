using System;
using System.Collections.Generic;
using Larva.Core.Configuration;
using Larva.Core.Configuration.MemoryConfig;
using Xunit;

namespace Larva.Core.Tests
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void TestMemoryConfigSetWithNotOverride()
        {
            ModuleManager.Instance.UseMemoryConfiguration(canOverride: true);
            MemoryConfigurationManager.Instance.Set("key1", "value1", true);
            MemoryConfigurationManager.Instance.Set("key1", "value2", false);

            Assert.Equal("value1", ConfigurationModule.Instance.Get("key1"));
        }

        [Fact]
        public void TestMemoryConfigSetWithOverride()
        {
            ModuleManager.Instance.UseMemoryConfiguration(canOverride: true);
            MemoryConfigurationManager.Instance.Set("key1", "value1", true);
            MemoryConfigurationManager.Instance.Set("key1", "value2", true);

            Assert.Equal("value2", ConfigurationModule.Instance.Get("key1"));
        }

        [Fact]
        public void TestMemoryConfigSetSectionWithNotOverride()
        {
            ModuleManager.Instance.UseMemoryConfiguration(canOverride: true);
            var section1 = new MemorySectionConfig("section1", new Dictionary<string,object>
            {
                {"key1", "value1"},
            });
            var section2 = new MemorySectionConfig("section1", new Dictionary<string,object>
            {
                {"key1", "value2"},
            });
            MemoryConfigurationManager.Instance.SetSection(section1, true);
            MemoryConfigurationManager.Instance.SetSection(section2, false);

            Assert.Equal(section1, ConfigurationModule.Instance.GetSection("section1"));
        }

        [Fact]
        public void TestMemoryConfigSetSectionWithOverride()
        {
            ModuleManager.Instance.UseMemoryConfiguration(canOverride: true);
            var section1 = new MemorySectionConfig("section1", new Dictionary<string,object>
            {
                {"key1", "value1"},
            });
            var section2 = new MemorySectionConfig("section1", new Dictionary<string,object>
            {
                {"key1", "value2"},
            });
            MemoryConfigurationManager.Instance.SetSection(section1, true);
            MemoryConfigurationManager.Instance.SetSection(section2, true);

            Assert.Equal(section2, ConfigurationModule.Instance.GetSection("section1"));
        }

        [Fact]
        public void TestMemorySectionConfigSetWithNotOverride()
        {
            var section1 = new MemorySectionConfig("section1");
            section1.Set("key1", "value1", true);
            section1.Set("key1", "value2", false);

            Assert.Equal("value1", section1.Get("key1"));
        }

        [Fact]
        public void TestMemorySectionConfigSetWithOverride()
        {
            var section1 = new MemorySectionConfig("section1");
            section1.Set("key1", "value1", true);
            section1.Set("key1", "value2", true);

            Assert.Equal("value2", section1.Get("key1"));
        }
    }
}