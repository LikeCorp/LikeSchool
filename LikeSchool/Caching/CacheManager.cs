using System.Web;
using System.Web.Caching;

namespace LikeSchool.Caching
{
    public class CacheManager : ICacheManager
    {
        #region ICacheManager Members 

        public void Add(string key, object value)
        {
            HttpRuntime.Cache.Add(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public bool Contains(string key)
        {
            return HttpRuntime.Cache.Get(key) != null;
        }

        public int Count()
        {
            return HttpRuntime.Cache.Count;
        }

        public void Insert(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public T Get<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }

        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public object this[string key]
        {
            get
            {
                return HttpRuntime.Cache[key];
            }
            set
            {
                HttpRuntime.Cache[key] = value;
            }
        }

        #endregion
    }
}
