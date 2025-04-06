using Microsoft.AspNetCore.Mvc;
using Redis.Business.Contact;
namespace Redis.Controllers
{
    [ApiController]
    [Route("RedisApi")]
    public class RedisController : Controller
    {
        private readonly IRedisService redis;
        public RedisController(IRedisService redis)
        {
            this.redis = redis;
        }

        [HttpGet("Get")]
        public async Task<string> GetRedis(string? key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "Anahtarınızı kontrol edin";
            }
            return await redis.GetStringAsync(key);            
        }
               
        [HttpPost("Set")]
        public async Task<string> SetRedis(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                return  "Anahtar ve değer boş olamaz.";
               
            }
            await redis.SetStringAsync(key, value);
            return $"'{key}' anahtarına '{value}' değeri başarıyla kaydedildi.";
        }
    }
}

