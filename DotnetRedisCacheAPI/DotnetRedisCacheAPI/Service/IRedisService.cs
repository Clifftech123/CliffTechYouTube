namespace DotnetRedisCacheAPI.Service
{
    public interface IRedisService
    {

        Task<T> GetDataAsync<T>(string key);
        Task<bool> SetDataAsync<T>(string key, T value, DateTime expirationTime);
    }
}
