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
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Transient);
            IocContainer.Instance.Register<INoticeService, EmailNoticeService>(life: LifetimeScope.Transient);
            IocContainer.Instance.Build();

            var noticeService1 = IocContainer.Instance.Resolve<INoticeService>();
            var noticeService2 = IocContainer.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(EmailNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), noticeService2.GetType());
            Assert.NotEqual(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterWithTransient()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Transient);
            IocContainer.Instance.Build();

            var noticeService1 = IocContainer.Instance.Resolve<INoticeService>();
            var noticeService2 = IocContainer.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.NotEqual(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterByServiceNameWithTransient()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Transient);
            IocContainer.Instance.Register<INoticeService, EmailNoticeService>(serviceName: "email", life: LifetimeScope.Transient);
            IocContainer.Instance.Build();

            var smsNoticeService1 = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            var smsNoticeService2 = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService2.GetType());
            Assert.NotEqual(smsNoticeService1, smsNoticeService2);
            var emailNoticeService1 = IocContainer.Instance.ResolveNamed<INoticeService>("email");
            var emailNoticeService2 = IocContainer.Instance.ResolveNamed<INoticeService>("email");
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService2.GetType());
            Assert.NotEqual(emailNoticeService1, emailNoticeService2);
        }

        [Fact]
        public void TestRegisterWithSingleton()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>(life: LifetimeScope.Singleton);
            IocContainer.Instance.Build();

            var noticeService1 = IocContainer.Instance.Resolve<INoticeService>();
            var noticeService2 = IocContainer.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterByServiceNameWithSingleton()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Singleton);
            IocContainer.Instance.Register<INoticeService, EmailNoticeService>(serviceName: "email", life: LifetimeScope.Singleton);
            IocContainer.Instance.Build();

            var smsNoticeService1 = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            var smsNoticeService2 = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), smsNoticeService2.GetType());
            Assert.Equal(smsNoticeService1, smsNoticeService2);
            var emailNoticeService1 = IocContainer.Instance.ResolveNamed<INoticeService>("email");
            var emailNoticeService2 = IocContainer.Instance.ResolveNamed<INoticeService>("email");
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService1.GetType());
            Assert.Equal(typeof(EmailNoticeService), emailNoticeService2.GetType());
            Assert.Equal(emailNoticeService1, emailNoticeService2);
        }

        [Fact]
        public void TestRegisterType()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.RegisterType(typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocContainer.Instance.Build();

            var noticeService1 = IocContainer.Instance.Resolve<SmsNoticeService>();
            var noticeService2 = IocContainer.Instance.Resolve<SmsNoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterTypeByServiceType()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.RegisterType(typeof(INoticeService), typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocContainer.Instance.Build();

            var noticeService1 = IocContainer.Instance.Resolve<INoticeService>();
            var noticeService2 = IocContainer.Instance.Resolve<INoticeService>();
            Assert.Equal(typeof(SmsNoticeService), noticeService1.GetType());
            Assert.Equal(typeof(SmsNoticeService), noticeService2.GetType());
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterInstance()
        {
            var noticeService1 = new SmsNoticeService();
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.RegisterInstance<INoticeService>(noticeService1);
            IocContainer.Instance.Build();

            var noticeService2 = IocContainer.Instance.Resolve<INoticeService>();
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestRegisterInstanceByServiceName()
        {
            var noticeService1 = new SmsNoticeService();
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.RegisterInstance<INoticeService>(noticeService1, serviceName: "sms");
            IocContainer.Instance.Build();

            var noticeService2 = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(noticeService1, noticeService2);
        }

        [Fact]
        public void TestIsRegistered()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.RegisterType(typeof(SmsNoticeService), life: LifetimeScope.Singleton);
            IocContainer.Instance.Build();

            var isRegistered = IocContainer.Instance.IsRegistered<SmsNoticeService>();
            Assert.True(isRegistered);
        }

        [Fact]
        public void TestIsRegisteredWithServiceName()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>(serviceName: "sms", life: LifetimeScope.Singleton);
            IocContainer.Instance.Build();

            var isRegistered1 = IocContainer.Instance.IsRegistered<INoticeService>(serviceName: "sms");
            var isRegistered2 = IocContainer.Instance.IsRegistered<INoticeService>(serviceName: "email");
            Assert.True(isRegistered1);
            Assert.False(isRegistered2);
        }

        [Fact]
        public void TestRegisterByAssembly()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.RegisterByAssembly(Assembly.GetExecutingAssembly());
            IocContainer.Instance.Build();

            var userApplication = IocContainer.Instance.Resolve<IUserApplicationService>();
            userApplication.CreateUser(new User { Name = "Jerry Bai" });
        }

        [Fact]
        public void TestReplaceWhenServiceInstanceRegistering()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.OnServiceInstanceRegistering += (sender, e) =>
            {
                if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
                {
                    e.SetNewInstance(new EmailNoticeService());
                }
            };
            IocContainer.Instance.RegisterInstance<INoticeService>(new SmsNoticeService(), "sms");
            IocContainer.Instance.Build();

            var noticeService = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(EmailNoticeService), noticeService.GetType());
        }

        [Fact]
        public void TestReplaceServiceTypeRegistering()
        {
            ModuleManager.Instance.UseAutofac(canOverride: true);
            IocContainer.Instance.OnServiceTypeRegistering += (sender, e) =>
            {
                if (e.ServiceName == "sms" && e.ServiceType == typeof(INoticeService))
                {
                    e.SetNewImplementationType(typeof(EmailNoticeService));
                }
            };
            IocContainer.Instance.Register<INoticeService, SmsNoticeService>("sms");
            IocContainer.Instance.Build();

            var noticeService = IocContainer.Instance.ResolveNamed<INoticeService>("sms");
            Assert.Equal(typeof(EmailNoticeService), noticeService.GetType());
        }
    }
}
