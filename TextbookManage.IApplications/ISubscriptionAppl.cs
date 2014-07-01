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
        /// 按教材生成订单
        /// </summary>
        /// <param name="textbookName"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsByTextbook(string term, string textbookName, string isbn);

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
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsBySchoolId(string term, string schoolId);

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
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsByPress(string term, string press);

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <param name="booksellerId"></param>
        /// <param name="spareCount"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitSubscriptions(string booksellerId, string spareCount, IEnumerable<SubscriptionForSubmitView> subscriptions);

        /// <summary>
        /// 取征订状态
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<FeedbackStateView> GetFeedbackState();

        /// <summary>
        /// 取订单的出版社
        /// </summary>
        /// <param name="term">学期</param>
        /// <param name="booksellerId">书商ID</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<string> GetPressByBookseller(string term, string booksellerId);

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="term">学年学期</param>
        /// <param name="booksellerId">书商ID</param>
        /// <param name="press">出版社名称</param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForFeedbackView> GetSubscriptions(string term, string booksellerId, string press);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView RemoveSubscriptions(IEnumerable<SubscriptionForFeedbackView> subscriptions);
    }
}
