namespace TextbookManage.Infrastructure.Cache
{
    using System;

    /// <summary>
    /// 表示由此特性所描述的方法，能够获得来自Byteart Retail基础结构层所提供的缓存功能。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CacheAttribute : Attribute
    {
        #region Ctor
        /// <summary>
        /// 初始化一个新的<c>CachingAttribute</c>类型。
        /// </summary>
        /// <param name="method">缓存方式。</param>
        public CacheAttribute(CacheMethod method)
        {
            Method = method;
        }
        /// <summary>
        /// 初始化一个新的<c>CachingAttribute</c>类型。
        /// </summary>
        /// <param name="method">缓存方式。</param>
        /// <param name="correspondingMethodNames">与当前缓存方式相关的方法名称。注：此参数仅在缓存方式为Remove时起作用。</param>
        public CacheAttribute(CacheMethod method, params string[] correspondingMethodNames)
            : this(method)
        {
            CorrespondingMethodNames = correspondingMethodNames;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 获取或设置缓存方式。
        /// </summary>
        public CacheMethod Method { get; set; }

        /// <summary>
        /// 获取或设置与当前缓存方式相关的方法名称。注：此参数仅在缓存方式为Remove时起作用。
        /// </summary>
        public string[] CorrespondingMethodNames { get; set; }
        #endregion
    }
}
