namespace TextbookManage.Infrastructure.Cache
{

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.Caching;

    public class CacheProvider : ICacheProvider
    {

        #region 属性与构造函数

        /// <summary>
        /// 内存缓存对象
        /// </summary>
        readonly MemoryCache _cache;

        /// <summary>
        /// 默认过期策略
        /// 相对过期，1分钟
        /// </summary>
        readonly CacheItemPolicy _defaultPolicy;

        public CacheProvider()
        {
            _cache = new MemoryCache("TextbookManage");
            _defaultPolicy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(0, 1, 0) };
        }

        #endregion

        #region 实现接口

        public void Add(string key, string valKey, object value, CacheItemPolicy policy = null)
        {
            if (policy == null)
            {
                policy = _defaultPolicy;
            }

            //字典，保存输入参数与方法的返回值
            Dictionary<string, object> dict = null;
            //如果存在该方法的缓存项，则更新
            if (_cache.Contains(key))
            {
                dict = (Dictionary<string, object>)_cache[key];
                dict[valKey] = value;
            }
            else
            {
                dict = new Dictionary<string, object>();
                dict.Add(valKey, value);
            }

            _cache.Set(key, dict, policy);
        }

        public object Get(string key, string valKey)
        {
            //缓存中是否存在该key
            if (_cache.Contains(key))
            {
                var dict = (Dictionary<string, object>)_cache.Get(key);
                if (dict != null && dict.ContainsKey(valKey))
                    return dict[valKey];
                else
                    return null;
            }
            return null;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByKey(string key)
        {
            foreach (var item in _cache)
            {
                if (item.Key.Contains(key))
                {
                    Remove(item.Key);
                }
            }
        }

        public bool Exists(string key)
        {
            return _cache.Contains(key);
        }

        public bool Exists(string key, string valKey)
        {
            //缓存中是否存在该key
            if (_cache.Contains(key))
            {
                //缓存字典中是否存在该valkey
                var dict = (Dictionary<string, object>)_cache.Get(key);
                return dict.ContainsKey(valKey);
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
