using DependencyInjection.API.Interface;

namespace DependencyInjection.API.Service
{
    public class TimestampService : ITimestampService
    {
        private readonly DateTime _timestamp;
        public TimestampService()
        {

            _timestamp = DateTime.UtcNow;

        }

        public DateTime GetTimeStamp() => _timestamp;
    }
}
