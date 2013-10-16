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
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionByTextbook(string textbookName, string isbn);

        /// <summary>
        /// 取待征订的学院，
        /// 按学生学院汇总
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SchoolView> GetSchoolWithNotSub();

        /// <summary>
        /// 按学院生成订单
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SubscriptionForSubmitView> CreateSubscriptionBySchoolId(string schoolId);

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="subscriptions"></param>
        /// <param name="booksellerId"></param>
        /// <param name="spareCount"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitSubscription(IEnumerable<SubscriptionForSubmitView> subscriptions, string booksellerId, string spareCount);
    }
}
