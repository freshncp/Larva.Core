namespace Larva.Autofac.Tests.IocTestData
{
    public class EmailNoticeService : INoticeService
    {
        public string ServiceName { get { return "Email"; } }
    }
}