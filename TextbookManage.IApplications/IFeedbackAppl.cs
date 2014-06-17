using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 回告
    /// </summary>
    [ServiceContract]
    public interface IFeedbackAppl
    {
        /// <summary>
        /// 由登录名，取未回告订单
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForFeedbackView> GetSubscriptionWithNotFeedback(string term,string loginName);

        /// <summary>
        /// 提交回告
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <param name="person"></param>
        /// <param name="feedbackState"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitFeedback(IEnumerable<SubscriptionForFeedbackView> subscriptions, string loginName, string feedbackState, string remark);

        /// <summary>
        /// 取书商
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<BooksellerView> GetBookseller(string loginName);

        /// <summary>
        /// 取回告状态
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<FeedbackStateView> GetFeedbackState();

        /// <summary>
        /// 由书商ID，回告状态，取订单
        /// </summary>
        /// <param name="booksellerId"></param>
        /// <param name="feedbackState"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForFeedbackView> GetSubscriptionByBooksellerId(string term, string booksellerId, string feedbackStateName);

        /// <summary>
        /// 由订单Id，取回告
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        FeedbackView GetFeedbackBySubscriptionId(string subscriptionId);

        /// <summary>
        /// 由登录名，取回告人姓名
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        string GetFeedbackPerson(string loginName);
    }
}
