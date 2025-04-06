namespace Redis.Business.Contact
{
    public interface IRedisService
    {
        Task<bool> SetStringAsync(string key, string value);
        Task<string> GetStringAsync(string key);
    }
}
