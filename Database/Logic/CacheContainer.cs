using System;
using System.Collections.Generic;

///////////////////////////////////////////////////
//Do not modify this file. It is auto generated. //
///////////////////////////////////////////////////

namespace CALI.Database.Logic
{
    public class CacheContainer<TId>
    {
        private static readonly Dictionary<Type, Dictionary<TId, CacheContainerItem>>
            _Cache = new Dictionary<Type, Dictionary<TId, CacheContainerItem>>();

        private class CacheContainerItem
        {
            public ICacheContainerEnabled<TId> Content;
            public long Expires;

            public CacheContainerItem(ICacheContainerEnabled<TId> content)
            {
                Content = content;

                Expires =
                    content.Cache_ExpireInMiliseconds == -1
                    ? -1
                    : DateTime.Now.AddMilliseconds(content.Cache_ExpireInMiliseconds).Ticks;
            }
        }

        public static void Cache(ICacheContainerEnabled<TId> obj)
        {
            lock (_Cache)
            {
                var type = obj.GetType();
                if (!_Cache.ContainsKey(type)) _Cache.Add(type, new Dictionary<TId, CacheContainerItem>());
                if (!_Cache[type].ContainsKey(obj.Cache_Identity))
                {
                    _Cache[type].Add(obj.Cache_Identity, new CacheContainerItem(obj));
                }
                else
                {
                    _Cache[type][obj.Cache_Identity] = new CacheContainerItem(obj);
                }
            }
        }
        public static T Get<T>(TId identity)
        {
            lock (_Cache)
            {
                var type = typeof(T);
                if (!_Cache.ContainsKey(type)) return default(T);
                if (!_Cache[type].ContainsKey(identity)) return default(T);

                //If not expired, return it.
                var item = _Cache[type][identity];
                if (item.Expires == -1 || item.Expires >= DateTime.Now.Ticks)
                    return (T)item.Content;

                //Expired cache, allow lazy GC.
                _Cache[type].Remove(identity);
                return default(T);

            }
        }
        public static void Clear<T>()
        {
            lock (_Cache)
            {
                var type = typeof(T);
                if (!_Cache.ContainsKey(type)) return;
                _Cache[type].Clear();
            }
        }
        public static void Clear()
        {
            lock (_Cache)
            {
                _Cache.Clear();
            }
        }
    }

    public static class CacheContainerExtensions
    {
        public static void CacheThis<TId>(this ICacheContainerEnabled<TId> c)
        {
            CacheContainer<TId>.Cache(c);
        }
        public static void CacheThis<T, TId>(this List<T> list)
        {
            foreach (var c in list)
                if (c is ICacheContainerEnabled<TId>)
                    CacheContainer<TId>.Cache((ICacheContainerEnabled<TId>)c);
        }
    }

    public interface ICacheContainerEnabled<TId>
    {
        TId Cache_Identity { get; }
        int Cache_ExpireInMiliseconds { get; }
    }
}
