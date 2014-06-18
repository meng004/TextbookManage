using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“FeedbackService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 FeedbackService.svc 或 FeedbackService.svc.cs，然后开始调试。
    public class FeedbackService : IFeedbackAppl
    {
        private readonly IFeedbackAppl _impl = ServiceLocator.Current.GetInstance<IFeedbackAppl>();



        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionWithNotFeedback(string term, string loginName)
        {
            return _impl.GetSubscriptionWithNotFeedback(term, loginName);
        }

        public ResponseView SubmitFeedback(IEnumerable<SubscriptionForFeedbackView> subscriptions, string loginName, string feedbackState, string remark)
        {
            return _impl.SubmitFeedback(subscriptions, loginName, feedbackState, remark);
        }

        public IEnumerable<BooksellerView> GetBookseller(string loginName)
        {
            return _impl.GetBookseller(loginName);
        }

        public IEnumerable<FeedbackStateView> GetFeedbackState()
        {
            return _impl.GetFeedbackState();
        }

        public IEnumerable<SubscriptionForFeedbackView> GetSubscriptionByBooksellerId(string term, string booksellerId, string feedbackStateName)
        {
            return _impl.GetSubscriptionByBooksellerId(term, booksellerId, feedbackStateName);
        }

        public FeedbackView GetFeedbackBySubscriptionId(string subscriptionId)
        {
            return _impl.GetFeedbackBySubscriptionId(subscriptionId);
        }

        public string GetFeedbackPerson(string loginName)
        {
            return _impl.GetFeedbackPerson(loginName);
        }
    }
}
