using Larva.Core.Ioc;

namespace Larva.Autofac.Tests.IocTestData
{
    [Larva.Core.Ioc.IocService]
    public class UserApplicationService : IUserApplicationService
    {
        private IUserRepository _userRepository;
        private IIocResolver _iocResolver;

        public UserApplicationService(IUserRepository userRepository, IIocResolver iocResolver)
        {
            _userRepository = userRepository;
            _iocResolver = iocResolver;
        }

        public void CreateUser(User user)
        {
            var lockerService = _iocResolver.Resolve<ILockService>();
            lockerService.Execute(nameof(User), () =>
            {
                _userRepository.AddUser(user);
            });
        }
    }
}