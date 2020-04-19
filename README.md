# Larva.Core

基础框架，基于模块化管理。包含一些常用模块，旨在为基于此框架之上的上层应用，提供一个抽象层，便于替换各个模块。

此框架，无任何nuget包依赖。

核心模块接口：IModuleManager，通过对此接口添加扩展类，实现模块开发。

每个抽象模块，包含抽象接口、模块扩展类；每个实现模块，包含模块扩展类；模块扩展类，额外定义模块名、模块实例。

已定义的抽象模块：

- Larva.Core.Configuration

- Larva.Core.Ioc

- Larva.Core.Logging

- Larva.Core.Serialization.Binary

- Larva.Core.Serialization.Json

- Larva.Core.Serialization.Xml

已实现的模块：

- Larva.Autofac

- Larva.Log4Net

- Larva.NewtonsoftJson


## 抽象模块介绍

### Larva.Core.Configuration 模块

应用配置配置，有配置块概念，配置块内部有独立配置列表，配置块之间是扁平关系。

```csharp
using Larva.Core.Configuration;

Larva.Core.ModuleManager.Instance.UseConfiguration(<custom>);

// 按Key获取配置项
ConfigurationModule.Instance.Get("key1");

// 按SectionName获取配置块
var section = ConfigurationModule.Instance.GetSection("section1");
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

### Larva.Core.Ioc 模块

用于依赖注入。

```csharp
using Larva.Core.Ioc;

Larva.Core.ModuleManager.Instance.UseIoc(<custom>);

// 按程序集注册
IocModule.RegisterByAssembly(<assembly>);
// 注册完后，需要执行构建。
IocModule.Instance.Build();

// 解析，支持通过构造函数进行注入
var userRepository = IocModule.Instance.Resolve<IUserRepository>();

// 支持注册服务实例时替换
IocModule.Instance.OnServiceInstanceRegistering += (sender, e) =>
{
    if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
    {
        e.SetNewInstance(new EmailNoticeService());
    }
};

// 支持注册服务类型时替换
IocModule.Instance.OnServiceTypeRegistering += (sender, e) =>
{
    if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
    {
        e.SetNewImplementationType(typeof(EmailNoticeService));
    }
};
 
```

### Larva.Core.Logging 模块

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

Larva.Core.ModuleManager.Instance.UseFileLog(<logPath>);
```

- 日志目录可定义，默认所在目录：`<AppDomain.BaseDirectory>`/logs/

- 文件命名：`<AssemblyName>`_`<yyyy-MM-dd>`.log

- 按日期自动切换新日志文件

### Larva.Core.Serialization.Binary 模块

二进制序列化模块，内置BinaryFormatter的封装。

```csharp
using Larva.Core.Serialization.Binary;

Larva.Core.ModuleManager.Instance.UseBinarySerialization(<custom>);
```

#### BinaryFormatter

```csharp
using Larva.Core.Serialization.Binary;

Larva.Core.ModuleManager.Instance.UseBinaryFormatter(<custom>);
var text1 = "This is a text.";
var buffer = BinarySerializationModule.Instance.Serialize(text1);
var text2 = BinarySerializationModule.Instance.Deserialize(typeof(string), buffer); 
```

### Larva.Core.Serialization.Json 模块

Json序列化模块。

```csharp
using Larva.Core.Serialization.Json;

Larva.Core.ModuleManager.Instance.UseJsonSerialization(<custom>);
```


### Larva.Core.Serialization.Xml 模块

Xml序列化模块。

```csharp
using Larva.Core.Serialization.Xml;

Larva.Core.ModuleManager.Instance.UseXmlSerialization(<custom>);
```

## 实现模块介绍

### Larva.Autofac 模块

Autofac 适配器。

```csharp
using Larva.Autofac;
using Larva.Core.Ioc;

Larva.Core.ModuleManager.Instance.UseAutofac();
```


### Larva.Log4Net 模块

Log4Net 适配器。

```csharp
using Larva.Log4Net;
using Larva.Core.Logging;

Larva.Core.ModuleManager.Instance.UseLog4Net("log4net.config");
```

### Larva.NewtonsoftJson 模块

NewtonsoftJson 适配器。

```csharp
using Larva.NewtonsoftJson;
using Larva.Core.Serialization.Json;

Larva.Core.ModuleManager.Instance.UseNewtonsoftJson();
```
