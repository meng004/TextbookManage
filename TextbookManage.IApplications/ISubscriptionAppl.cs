using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    [ServiceContract]
    public interface ISubscriptionAppl
    {

        /// <summary>
        /// 取书商
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<BooksellerView> GetBookseller();

        /// <summary>
        /// 按教材生成订单
        /// </summary>
        /// <param name="textbookName"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionByTextbook(string term, string textbookName, string isbn);

        /// <summary>
        /// 取待征订的学院，
        /// 按开课学院汇总
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SchoolView> GetSchoolWithNotSub(string term);

        /// <summary>
        /// 按学院生成订单
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionBySchoolId(string term, string schoolId);

        /// <summary>
        /// 取待征订的出版社
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<string> GetPressWithNotSub(string term);

        /// <summary>
        /// 按出版社生成订单
        /// </summary>
        /// <param name="press"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionByPress(string term, string press);

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <param name="booksellerId"></param>
        /// <param name="spareCount"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitSubscription(string term, string booksellerId, string spareCount, IEnumerable<SubscriptionForSubmitView> subscriptions);

        /// <summary>
        /// 取征订状态
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<FeedbackStateView> GetFeedbackState();

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="term">学年学期</param>
        /// <param name="state">订单状态</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForSubmitView> GetSubscriptions(string term, FeedbackStateView state);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView RemoveSubscription(IEnumerable<SubscriptionForSubmitView> subscriptions);
    }
}
