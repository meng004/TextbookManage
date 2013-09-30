namespace TextbookManage.Infrastructure.TypeAdapter
{
    using System.Collections.Generic;

    /// <summary>
    /// 对象类型转换
    /// 将DTO => model，或model => DTO
    /// </summary>
    public interface ITypeAdapter
    {
        /// <summary>
        /// 将对象由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new();

        /// <summary>
        /// 将对象由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        TTarget Adapt<TTarget>(object source) where TTarget : class, new();

        /// <summary>
        /// 将对象集合由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        IEnumerable<TTarget> Adapt<TSource, TTarget>(IEnumerable<TSource> source)
            where TSource : class
            where TTarget : class,new();

        /// <summary>
        /// 将对象集合由源类型转换为目标类型
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <returns>目标类型的对象</returns>
        IEnumerable<TTarget> Adapt<TTarget>(IEnumerable<object> source)
            where TTarget : class,new();
    }
}
