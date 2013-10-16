using System;
using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“FeedbackApprovalService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 FeedbackApprovalService.svc 或 FeedbackApprovalService.svc.cs，然后开始调试。
    public class FeedbackApprovalService : IFeedbackApprovalAppl
    {
        private readonly IFeedbackApprovalAppl _impl = ServiceLocator.Current.GetInstance<IFeedbackApprovalAppl>();

        public string GetAuditor(string loginName)
        {
            return _impl.GetAuditor(loginName);
        }

        public IEnumerable<BooksellerView> GetBooksellerWithNotApproval(string loginName)
        {
            return _impl.GetBooksellerWithNotApproval(loginName);
        }

        public IEnumerable<FeedbackForApprovalView> GetFeedbackWithNotApproval(string loginName, string booksellerId)
        {
            return _impl.GetFeedbackWithNotApproval(loginName, booksellerId);
        }

        public ResponseView SubmitFeedbackApproval(IEnumerable<FeedbackForApprovalView> feedbacks, string loginName, string suggestion, string remark)
        {
            return _impl.SubmitFeedbackApproval(feedbacks, loginName, suggestion, remark);
        }
    }
}
