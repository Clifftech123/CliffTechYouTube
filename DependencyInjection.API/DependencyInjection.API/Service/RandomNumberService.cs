using DependencyInjection.API.Interface;

namespace DependencyInjection.API.Service
{
    public class RandomNumberService : IRandomNumberService
    {
        private int _randomNumber;

        public RandomNumberService()
        {
            _randomNumber = new Random().Next(1, 200) + 1;
        }
        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
