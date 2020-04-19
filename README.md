# Larva.Core

基础框架，基于模块化管理。包含一些常用模块，旨在为基于此框架之上的上层应用，提供一个抽象层，便于替换各个模块。

此框架，无任何nuget包依赖。

核心模块接口：IModuleManager，通过对此接口添加扩展类，实现模块开发。

每个抽象模块，包含抽象接口、模块扩展类、代理，这3部分。

每个模块，包含模块扩展类、代理，这2部分。

已定义的抽象模块：

- Larva.Core.Configuration.ConfigurationModule

- Larva.Core.Ioc.IocModule

- Larva.Core.Logging.LoggingModule

- Larva.Core.Serialization.Binary.BinarySerializationModule

- Larva.Core.Serialization.Json.JsonSerializationModule

- Larva.Core.Serialization.Xml.XmlSerializationModule

## 模块介绍

### Configuration 模块

应用配置配置，有配置块概念，配置块内部有独立配置列表，配置块之间是扁平关系。

```csharp
using Larva.Core.Configuration;

Larva.Core.ModuleManager.Instance.UseConfiguration(<custom>);

// 按Key获取配置项
ConfigurationProxy.Instance.Get("key1");

// 按SectionName获取配置块
var section = ConfigurationProxy.Instance.GetSection("section1");
// 按Key获取配置项
section.Instance.Get("key1");
```

#### MemoryConfig

内存配置，仅用于测试时使用。

```csharp
using Larva.Core.Configuration;
using Larva.Core.Configuration.MemoryConfig;

Larva.Core.ModuleManager.Instance.UseMemoryConfiguration();

// 设置值
MemoryConfigurationManager.Instance.Set("key1", 123);

var section1 = new MemorySectionConfig("section1", new Dictionary<string,object>
{
    {"key1", "value1"},
});
// 配置块设置值
section1.Set("key2", 1);
// 设置配置块
MemoryConfigurationManager.Instance.SetSection(section1);
```

### Ioc 模块

用于依赖注入。

```csharp
using Larva.Core.Ioc;

Larva.Core.ModuleManager.Instance.UseIoc(<custom>);
```

### Logging 模块

已内置ConsoleLog、FileLog。

```csharp
using Larva.Core.Logging;

Larva.Core.ModuleManager.Instance.UseLogging(<custom>);
```

#### ConsoleLog

控制台输出，用于单元测试。

内置的日志格式：日期+时间+日志级别+日志来源类型名+日志内容+异常消息+异常堆栈。

```csharp
using Larva.Core.Logging;

Larva.Core.ModuleManager.Instance.UseConsoleLog();
```

#### FileLog

文件输出，可用于实际项目。

内置的日志格式：日期+时间+日志级别+日志来源类型名+日志内容+异常消息+异常堆栈。

```csharp
using Larva.Core.Logging;

Larva.Core.ModuleManager.Instance.UseFileLog();
```

- 日志目录可定义，默认所在目录：`<AppDomain.BaseDirectory>`/logs/

- 文件命名：`<AssemblyName>`_`<yyyy-MM-dd>`.log

- 按日期自动切换新日志文件

### Serialization.Binary 模块

二进制序列号模块，内置BinaryFormatter的封装。

```csharp
using Larva.Core.Serialization.Binary;

Larva.Core.ModuleManager.Instance.UseBinarySerialization(<custom>);
```

#### BinaryFormatter

```csharp
using Larva.Core.Serialization.Binary;

Larva.Core.ModuleManager.Instance.UseBinaryFormatter(<custom>);
var text1 = "This is a text.";
var buffer = BinarySerializationProxy.Instance.Serialize(text1);
var text2 = BinarySerializationProxy.Instance.Deserialize(typeof(string), buffer); 
```

### Serialization.Json 模块

Json序列号模块。

```csharp
using Larva.Core.Serialization.Json;

Larva.Core.ModuleManager.Instance.UseJsonSerialization(<custom>);
```


### Serialization.Xml 模块

Xml序列号模块。

```csharp
using Larva.Core.Serialization.Xml;

Larva.Core.ModuleManager.Instance.UseXmlSerialization(<custom>);
```
