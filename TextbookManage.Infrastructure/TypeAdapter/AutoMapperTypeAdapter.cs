namespace TextbookManage.Infrastructure.TypeAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;

    public class AutoMapperTypeAdapter : ITypeAdapter
    {

        #region 构造函数

        /// <summary>
        /// 由配置类初始化AutoMapper
        /// </summary>
        public AutoMapperTypeAdapter()
        {
            //取配置文件
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                    {
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                    }
                }
            });
        }
        #endregion

        #region 实现 ITypeAdapter

        /// <summary>
        /// 将对象由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class,new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// 将对象由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        public TTarget Adapt<TTarget>(object source)
            where TTarget : class,new()
        {
            return Mapper.Map<TTarget>(source);
        }

        /// <summary>
        /// 将对象集合由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        public IEnumerable<TTarget> Adapt<TSource, TTarget>(IEnumerable<TSource> source)
            where TSource : class
            where TTarget : class, new()
        {
            //目标类型对象列表
            IList<TTarget> list = new List<TTarget>();

            //循环转换
            foreach (var item in source)
            {
                list.Add(Adapt<TSource, TTarget>(item));
            }

            return list;
        }

        /// <summary>
        /// 将对象集合由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        public IEnumerable<TTarget> Adapt<TTarget>(IEnumerable<object> source)
            where TTarget : class, new()
        {
            //目标类型对象列表
            IList<TTarget> list = new List<TTarget>();            

            //循环转换
            foreach (var item in source)
            {
                list.Add(Adapt<TTarget>(item));
            }

            return list;
        }
        #endregion

    }
}
