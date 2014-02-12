using System;
using System.Collections.Generic;

///////////////////////////////////////////////////
//Do not modify this file. It is auto generated. //
///////////////////////////////////////////////////

namespace CALI.WebSite.Services
{
    /// <summary>
    /// This class provides specific caching logic
    /// </summary>
    public class SpecificCacheContainer<TId, T>
    {
        private readonly Dictionary<TId, CacheContainerItem>
            _cache = new Dictionary<TId, CacheContainerItem>();

        private class CacheContainerItem
        {
            public T Content;
            public long Expires;

            public CacheContainerItem(T content, int expireInMs)
            {
                Content = content;
                Expires =
                    expireInMs == -1
                    ? -1
                    : DateTime.Now.AddMilliseconds(expireInMs).Ticks;
            }
        }

        public void Cache(TId identity, T content, int expireInMs)
        {
            lock (_cache)
            {
                if (!_cache.ContainsKey(identity))
                {
                    _cache.Add(identity, new CacheContainerItem(content,expireInMs));
                }
                else
                {
                    _cache[identity] = new CacheContainerItem(content, expireInMs);
                }
            }
        }
        public T Get(TId identity)
        {
            lock (_cache)
            {
                if (!_cache.ContainsKey(identity)) return default(T);

                //If not expired, return it.
                var item = _cache[identity];
                if (item.Expires == -1 || item.Expires >= DateTime.Now.Ticks)
                    return item.Content;

                //Expired cache, allow lazy GC.
                _cache.Remove(identity);
                return default(T);

            }
        }
        public void Clear(TId identity)
        {
            lock (_cache)
            {
                _cache.Remove(identity);
            }
        }
        public void Clear()
        {
            lock (_cache)
            {
                _cache.Clear();
            }
        }
    }
}
