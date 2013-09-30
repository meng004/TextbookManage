using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IServices
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        /// <summary>
        /// 取待下订单学院
        /// 学院为学生学院
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetSchoolWithNotSub();

        /// <summary>
        /// 按学院生成订单
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetBySchoolId(QueryRequest schoolId);

        /// <summary>
        /// 按教材生成订单
        /// </summary>
        /// <param name="textbookName"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetByTextbook(QueryRequest textbook);

        /// <summary>
        /// 新建订单
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <param name="subscriptions"></param>
        /// <param name="spareCount"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse Add(AddRequest subscriptions);

        /// <summary>
        /// 取回告状态
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetFeedbackState();

        /// <summary>
        /// 取书商的订单
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <param name="feedbackState"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QueryCollectionResponse GetByBooksellerId(QueryRequest booksellerId);

        /// <summary>
        /// 保存回告
        /// </summary>
        /// <param name="subscriptionIds"></param>
        /// <param name="feedbackPerson"></param>
        /// <param name="feedbackState"></param>
        /// <param name="remark"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        AddResponse AddFeedback(AddRequest feedback);

        /// <summary>
        /// 取回告
        /// </summary>
        /// <param name="declarationId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        QuerySingleResponse GetFeedbackByDeclarationId(QueryRequest declarationId);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="subscriptionIds"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        RemoveResponse Delete(RemoveRequest subscriptionIds);

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="booksellerId"></param>
        /// <param name="spareCount"></param>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ModifyResponse Modify(ModifyRequest subscription);

    }
}
