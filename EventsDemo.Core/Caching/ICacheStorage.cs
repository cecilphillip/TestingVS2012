using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo.Caching
{
    public interface ICacheService
    {
        bool Exists(string key);
        List<string> GetKeys();
        void Store(string key, object objectToCache);        
        void Store(string key, object objectToCache, TimeSpan slidingExpiration);
        void Remove(string key);
        T Retrieve<T>(string key);
    }
}
