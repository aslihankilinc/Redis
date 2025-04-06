using Redis.Business.Contact;
using StackExchange.Redis;
namespace Redis.Business.Service
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase redisDb;
        public RedisService(IConnectionMultiplexer redis)
        {
            this.redisDb = redis.GetDatabase();
        }
        public async Task<bool> SetStringAsync(string key, string value)
        {
            return await redisDb.StringSetAsync(key, value ,TimeSpan.FromMinutes(18));
            //return await redisDb.StringSetAsync(key, value);
        }
        public async Task<string> GetStringAsync(string key)
        {
            return await redisDb.StringGetAsync(key);
        }
    }
   
}
