using DependencyInjection.API.Interface;

namespace DependencyInjection.API.Service
{
    public class UserSessionService : IUserSessionService
    {
        private readonly string _userId;

        public UserSessionService()
        {
            _userId = $"Session_{DateTime.UtcNow.Ticks}";
        }
        public string GetSessionId() => _userId;

    }
}
