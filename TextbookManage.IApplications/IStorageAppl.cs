using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    [ServiceContract]
    public interface IStorageAppl
    {

        /// <summary>
        /// 由书商ID，取仓库
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StorageView> GetByBookSellerId(string booksellerId);

        /// <summary>
        /// 由登录名，取仓库
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<StorageView> GetByLoginName(string loginName);

        /// <summary>
        /// 由仓库ID，取仓库
        /// </summary>
        /// <param name="textbookId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        StorageView GetById(string storageId);

        /// <summary>
        /// 新增仓库
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView Add(StorageView storage);

        /// <summary>
        /// 修改仓库
        /// </summary>
        /// <param name="textbook"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView Modify(StorageView storage);

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="textbooks"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView Remove(IEnumerable<StorageView> storages);

    }
}
