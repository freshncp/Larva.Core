using System.Reflection;
using Larva.Autofac;
using Larva.Autofac.Tests.IocTestData;
using Larva.Core;
using Larva.Core.Ioc;
using Xunit;

namespace Larva.Autofac.Tests
{
    public class AutofacTests
    {
        [Fact]
        public void TestRegisterAgainWillOverrideLast()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Transient);
            IocModule.Instance.Register<INoticeService, EmailNoticeService>(life: LifetimeScope.Transient);
            IocModule.Instance.Build();

            var noticeService1 = IocModule.Instance.Resolve<INoticeService>();
            var noticeService2 = IocModule.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(EmailNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), noticeService2.GetType());
            Assert.NotEqual(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterWithTransient()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Transient);
            IocModule.Instance.Build();

            var noticeService1 = IocModule.Instance.Resolve<INoticeService>();
            var noticeService2 = IocModule.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.NotEqual(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterByServiceNameWithTransient()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Transient);
            IocModule.Instance.Register<INoticeService, EmailNoticeService>(serviceName: "email", life: LifetimeScope.Transient);
            IocModule.Instance.Build();

            var smsNoticeService1 = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            var smsNoticeService2 = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService2.GetType());
            Assert.NotEqual(smsNoticeService1, smsNoticeService2);
            var emailNoticeService1 = IocModule.Instance.ResolveNamed<INoticeService>("email");
            var emailNoticeService2 = IocModule.Instance.ResolveNamed<INoticeService>("email");
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService2.GetType());
            Assert.NotEqual(emailNoticeService1, emailNoticeService2);
        }

        [Fact]
        public void TestRegisterWithSingleton()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Singleton);
            IocModule.Instance.Build();

            var noticeService1 = IocModule.Instance.Resolve<INoticeService>();
            var noticeService2 = IocModule.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterByServiceNameWithSingleton()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Singleton);
            IocModule.Instance.Register<INoticeService, EmailNoticeService>(serviceName: "email", life: LifetimeScope.Singleton);
            IocModule.Instance.Build();

            var smsNoticeService1 = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            var smsNoticeService2 = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService2.GetType());
            Assert.Equal(smsNoticeService1, smsNoticeService2);
            var emailNoticeService1 = IocModule.Instance.ResolveNamed<INoticeService>("email");
            var emailNoticeService2 = IocModule.Instance.ResolveNamed<INoticeService>("email");
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService2.GetType());
            Assert.Equal(emailNoticeService1, emailNoticeService2);
        }

        [Fact]
        public void TestRegisterType()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.RegisterType(typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocModule.Instance.Build();

            var noticeService1 = IocModule.Instance.Resolve<SmsNoticeService>();
            var noticeService2 = IocModule.Instance.Resolve<SmsNoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterTypeByServiceType()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.RegisterType(typeof(INoticeService), typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocModule.Instance.Build();

            var noticeService1 = IocModule.Instance.Resolve<INoticeService>();
            var noticeService2 = IocModule.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterInstance()
        {
            var noticeService1 = new SmsNoticeService();
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.RegisterInstance<INoticeService>(noticeService1);
            IocModule.Instance.Build();

            var noticeService2 = IocModule.Instance.Resolve<INoticeService>();
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterInstanceByServiceName()
        {
            var noticeService1 = new SmsNoticeService();
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.RegisterInstance<INoticeService>(noticeService1, serviceName: "sms");
            IocModule.Instance.Build();

            var noticeService2 = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestIsRegistered()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.RegisterType(typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocModule.Instance.Build();

            var isRegistered = IocModule.Instance.IsRegistered<SmsNoticeService>();
            Assert.True(isRegistered);
        }

        [Fact]
        public void TestIsRegisteredWithServiceName()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Singleton);
            IocModule.Instance.Build();

            var isRegistered1 = IocModule.Instance.IsRegistered<INoticeService>(serviceName: "sms");
            var isRegistered2 = IocModule.Instance.IsRegistered<INoticeService>(serviceName: "email");
            Assert.True(isRegistered1);
            Assert.False(isRegistered2);
        }

        [Fact]
        public void TestRegisterByAssembly()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.RegisterByAssembly(Assembly.GetExecutingAssembly());
            IocModule.Instance.Build();

            var userApplication = IocModule.Instance.Resolve<IUserApplicationService>();
            userApplication.CreateUser(new User { Name = "Jerry Bai" });
        }

        [Fact]
        public void TestReplaceWhenServiceInstanceRegistering()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.OnServiceInstanceRegistering += (sender, e) =>
            {
                if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
                {
                    e.SetNewInstance(new EmailNoticeService());
                }
            };
            IocModule.Instance.RegisterInstance<INoticeService>(new SmsNoticeService(), "sms");
            IocModule.Instance.Build();

            var noticeService = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(EmailNoticeService), noticeService.GetType());
        }

        [Fact]
        public void TestReplaceServiceTypeRegistering()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocModule.Instance.OnServiceTypeRegistering += (sender, e) =>
            {
                if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
                {
                    e.SetNewImplementationType(typeof(EmailNoticeService));
                }
            };
            IocModule.Instance.Register<INoticeService, SmsNoticeService>("sms");
            IocModule.Instance.Build();

            var noticeService = IocModule.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(EmailNoticeService), noticeService.GetType());
        }
    }
}
