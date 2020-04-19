# Larva.Core

基础框架。包含一些常用模块，旨在为基于此框架之上的上层应用，提供一个抽象层，便于替换各个模块。

核心模块接口：IModuleManager，通过对此接口添加扩展类，实现模块开发。

已定义的抽象模块：

- Larva.Core.Configuration.ConfigurationModule

- Larva.Core.Ioc.IocModule

- Larva.Core.Logging.LoggingModule


## 模块介绍

### Configuration模块

应用配置配置，有配置块概念，配置块内部有独立配置列表，配置块之间是扁平关系。

```csharp
using Larva.Core.Configuration;

Larva.Core.ModuleManager.Instance.UseConfiguration(<custom>);

// 按Key获取配置项
ConfigurationManager.Instance.Get("key1");

// 按SectionName获取配置块
var section = ConfigurationManager.Instance.GetSection("section1");
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

### Ioc模块

用于依赖注入。

```csharp
Larva.Core.ModuleManager.Instance.UseIoc(<custom>);
```

### Logging模块

已内置ConsoleLog、FileLog。

```csharp
Larva.Core.ModuleManager.Instance.UseLogging(<custom>);
```

#### ConsoleLog

控制台输出，用于单元测试。

内置的日志格式：日期+时间+日志级别+日志来源类型名+日志内容+异常消息+异常堆栈。

```csharp
Larva.Core.ModuleManager.Instance.UseConsoleLog();
```

#### FileLog

文件输出，可用于实际项目。

内置的日志格式：日期+时间+日志级别+日志来源类型名+日志内容+异常消息+异常堆栈。

```csharp
Larva.Core.ModuleManager.Instance.UseFileLog();
```

- 日志目录可定义，默认所在目录：`<AppDomain.BaseDirectory>`/logs/

- 文件命名：`<AssemblyName>`_`<yyyy-MM-dd>`.log

- 按日期自动切换新日志文件
