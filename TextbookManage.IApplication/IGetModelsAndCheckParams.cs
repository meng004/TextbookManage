using System;
using System.Collections.Generic;

namespace TextbookManage.IApplications
{
    public interface IGetModelsAndCheckParams
    {
        /// <summary>
        /// 参数为空则返回0个元素的队列
        /// 先从缓存中取models
        /// 没有则从数据库中取，并写缓存
        /// </summary>
        /// <typeparam name="T">返回队列的元素类型</typeparam>
        /// <param name="key">缓存的Key</param>
        /// <param name="getFromDb">从数据库取数据的方法</param>
        /// <param name="args">输入参数</param>
        /// <returns></returns>
        IEnumerable<T> GetModelsByParams<T>(string key, Func<IEnumerable<T>> getFromDb, params string[] args) where T : class, new();

        /// <summary>
        /// 参数为空则返回默认对象
        /// 先从缓存中取model
        /// 没有则从数据库中取，并写缓存
        /// </summary>
        /// <typeparam name="T">返回元素类型</typeparam>
        /// <param name="key">缓存的Key</param>
        /// <param name="getFromDb">从数据库取数据的方法</param>
        /// <param name="args">输入参数</param>
        /// <returns></returns>
        T GetModelsByParams<T>(string key, Func<T> getFromDb, params string[] args) where T : class, new();
    }
}
