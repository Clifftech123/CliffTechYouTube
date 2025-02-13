using DependencyInjection.API.Interface;

namespace DependencyInjection.API.Service
{
    public class GuidGeneratorService : IGuidGeneratorService
    {

        public Guid GenerateGuid() => Guid.NewGuid();
    }
}
