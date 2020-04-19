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
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Transient);
            IocProxy.Instance.Register<INoticeService, EmailNoticeService>(life: LifetimeScope.Transient);
            IocProxy.Instance.Build();

            var noticeService1 = IocProxy.Instance.Resolve<INoticeService>();
            var noticeService2 = IocProxy.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(EmailNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), noticeService2.GetType());
            Assert.NotEqual(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterWithTransient()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Transient);
            IocProxy.Instance.Build();

            var noticeService1 = IocProxy.Instance.Resolve<INoticeService>();
            var noticeService2 = IocProxy.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.NotEqual(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterByServiceNameWithTransient()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Transient);
            IocProxy.Instance.Register<INoticeService, EmailNoticeService>(serviceName: "email", life: LifetimeScope.Transient);
            IocProxy.Instance.Build();

            var smsNoticeService1 = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            var smsNoticeService2 = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService2.GetType());
            Assert.NotEqual(smsNoticeService1, smsNoticeService2);
            var emailNoticeService1 = IocProxy.Instance.ResolveNamed<INoticeService>("email");
            var emailNoticeService2 = IocProxy.Instance.ResolveNamed<INoticeService>("email");
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService2.GetType());
            Assert.NotEqual(emailNoticeService1, emailNoticeService2);
        }

        [Fact]
        public void TestRegisterWithSingleton()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Singleton);
            IocProxy.Instance.Build();

            var noticeService1 = IocProxy.Instance.Resolve<INoticeService>();
            var noticeService2 = IocProxy.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterByServiceNameWithSingleton()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Singleton);
            IocProxy.Instance.Register<INoticeService, EmailNoticeService>(serviceName: "email", life: LifetimeScope.Singleton);
            IocProxy.Instance.Build();

            var smsNoticeService1 = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            var smsNoticeService2 = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService2.GetType());
            Assert.Equal(smsNoticeService1, smsNoticeService2);
            var emailNoticeService1 = IocProxy.Instance.ResolveNamed<INoticeService>("email");
            var emailNoticeService2 = IocProxy.Instance.ResolveNamed<INoticeService>("email");
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService2.GetType());
            Assert.Equal(emailNoticeService1, emailNoticeService2);
        }

        [Fact]
        public void TestRegisterType()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.RegisterType(typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocProxy.Instance.Build();

            var noticeService1 = IocProxy.Instance.Resolve<SmsNoticeService>();
            var noticeService2 = IocProxy.Instance.Resolve<SmsNoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterTypeByServiceType()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.RegisterType(typeof(INoticeService), typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocProxy.Instance.Build();

            var noticeService1 = IocProxy.Instance.Resolve<INoticeService>();
            var noticeService2 = IocProxy.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterInstance()
        {
            var noticeService1 = new SmsNoticeService();
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.RegisterInstance<INoticeService>(noticeService1);
            IocProxy.Instance.Build();

            var noticeService2 = IocProxy.Instance.Resolve<INoticeService>();
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterInstanceByServiceName()
        {
            var noticeService1 = new SmsNoticeService();
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.RegisterInstance<INoticeService>(noticeService1, serviceName: "sms");
            IocProxy.Instance.Build();

            var noticeService2 = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestIsRegistered()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.RegisterType(typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocProxy.Instance.Build();

            var isRegistered = IocProxy.Instance.IsRegistered<SmsNoticeService>();
            Assert.True(isRegistered);
        }

        [Fact]
        public void TestIsRegisteredWithServiceName()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Singleton);
            IocProxy.Instance.Build();

            var isRegistered1 = IocProxy.Instance.IsRegistered<INoticeService>(serviceName: "sms");
            var isRegistered2 = IocProxy.Instance.IsRegistered<INoticeService>(serviceName: "email");
            Assert.True(isRegistered1);
            Assert.False(isRegistered2);
        }

        [Fact]
        public void TestRegisterByAssembly()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.RegisterByAssembly(Assembly.GetExecutingAssembly());
            IocProxy.Instance.Build();

            var userApplication = IocProxy.Instance.Resolve<IUserApplicationService>();
            userApplication.CreateUser(new User { Name = "Jerry Bai" });
        }

        [Fact]
        public void TestReplaceWhenServiceInstanceRegistering()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.OnServiceInstanceRegistering += (sender, e) =>
            {
                if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
                {
                    e.SetNewInstance(new EmailNoticeService());
                }
            };
            IocProxy.Instance.RegisterInstance<INoticeService>(new SmsNoticeService(), "sms");
            IocProxy.Instance.Build();

            var noticeService = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(EmailNoticeService), noticeService.GetType());
        }

        [Fact]
        public void TestReplaceServiceTypeRegistering()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocProxy.Instance.OnServiceTypeRegistering += (sender, e) =>
            {
                if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
                {
                    e.SetNewImplementationType(typeof(EmailNoticeService));
                }
            };
            IocProxy.Instance.Register<INoticeService, SmsNoticeService>("sms");
            IocProxy.Instance.Build();

            var noticeService = IocProxy.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(EmailNoticeService), noticeService.GetType());
        }
    }
}
