using System;
using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    [ServiceContract]
    public interface IFeedbackApprovalAppl
    {
        /// <summary>
        /// 由登录名，获取当前登录用户姓名
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        string GetAuditor(string loginName);

        /// <summary>
        /// 由登录名，取待审书商
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<BooksellerView> GetBooksellerWithNotApproval(string loginName);

        /// <summary>
        /// 由登录名，书商ID，取待审回告
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<FeedbackForApprovalView> GetFeedbackWithNotApproval(string loginName, string booksellerId);

        /// <summary>
        /// 提交用书申报审核
        /// </summary>
        /// <param name="declarations"></param>
        /// <param name="auditor"></param>
        /// <param name="division"></param>
        /// <param name="suggestion"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]
        ResponseView SubmitFeedbackApproval(IEnumerable<FeedbackForApprovalView> feedbacks, string loginName, string suggestion, string remark);

    }
}
