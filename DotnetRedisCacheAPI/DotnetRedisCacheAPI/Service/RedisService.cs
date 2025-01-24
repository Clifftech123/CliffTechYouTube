
using StackExchange.Redis;
using System.Text.Json;

namespace DotnetRedisCacheAPI.Service
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _database;

        public RedisService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _database = redis.GetDatabase();
        }

        public async Task<T> GetDataAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            return value.IsNull ? default : JsonSerializer.Deserialize<T>(value);
        }

        public async Task<bool> SetDataAsync<T>(string key, T value, DateTime expirationTime)
        {
            var json = JsonSerializer.Serialize(value);
            return await _database.StringSetAsync(key, json, expirationTime - DateTime.Now);
        }
    }
}
