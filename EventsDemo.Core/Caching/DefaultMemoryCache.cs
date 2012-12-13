using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace EventsDemo.Caching
{
    public class DefaultMemoryCache : ICacheService
    {
        private const int defaultDayOffSet = 5;
        private static readonly ObjectCache cache = MemoryCache.Default;

        public virtual T Retrieve<T>(string key)
        {
            try
            {
                return (T)cache[key];
            }
            catch
            {
                return default(T);
            }
        }

        public virtual void Store(string key, object objectToCache)
        {
            if (DefaultMemoryCache.cache.Contains(key))
            {
                DefaultMemoryCache.cache.Remove(key);
            }
            DefaultMemoryCache.cache.Add(key, objectToCache, DateTime.Now.AddDays(defaultDayOffSet));
        }

        public virtual void Store(string key, object objectToCache, TimeSpan slidingExpiration)
        {
            if (DefaultMemoryCache.cache.Contains(key))
            {
                DefaultMemoryCache.cache.Remove(key);
            }
            DefaultMemoryCache.cache.Add(key, objectToCache, new CacheItemPolicy() { SlidingExpiration = slidingExpiration });
        }

        public virtual void Remove(string key)
        {
            DefaultMemoryCache.cache.Remove(key);
        }

        public virtual bool Exists(string key)
        {
            return DefaultMemoryCache.cache.Contains(key);
        }

        public virtual List<string> GetKeys()
        {
            return DefaultMemoryCache.cache.Select(keyValuePair => keyValuePair.Key).ToList();
        }
    }
}
