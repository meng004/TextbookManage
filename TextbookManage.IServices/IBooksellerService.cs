using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices
{
    [ServiceContract]
    public interface IBooksellerService
    {
        /// <summary>
        /// 取书商
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetAll();

        /// <summary>
        /// 根据ID，取书商
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QuerySingleResponse GetById(QueryRequest booksellerId);

        /// <summary>
        /// 新增
        /// </summary>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse Add(AddRequest bookseller);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="subscriptionIds"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        RemoveResponse Remove(RemoveRequest bookseller);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="booksellerId"></param>
        /// <param name="spareCount"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ModifyResponse Modify(ModifyRequest bookseller);
    }
}
