using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace S3Inovate.Core.Helpers
{
    public static class CacheHelperExtension
    {
        public static async Task SetCacheAsStringAsync
                 (this IDistributedCache distributedCache,
                 string cacheKey,
                 object cacheObject,
                 uint expirationTimeFromNowInSeconds)
        {
            await distributedCache
                .SetStringAsync(cacheKey,
                JsonConvert.SerializeObject(cacheObject),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expirationTimeFromNowInSeconds)
                });
        }

        public static async Task<T> GetCacheAsync<T>
       (this IDistributedCache distributedCache,
       string cacheKey)
        {
            var cacheString = await distributedCache
                   .GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheString))
                return JsonConvert.DeserializeObject<T>(cacheString);

            return default;
        }
    }
}
