using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“SubScriptionService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 SubScriptionService.svc 或 SubScriptionService.svc.cs，然后开始调试。
    public class SubscriptionService : ISubscriptionAppl
    {
        private readonly ISubscriptionAppl _impl = ServiceLocator.Current.GetInstance<ISubscriptionAppl>();

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsByTextbook(string term, string textbookName, string isbn)
        {
            return _impl.CreateSubscriptionsByTextbook(term, textbookName, isbn);
        }

        public IEnumerable<SchoolView> GetSchoolWithNotSub(string term)
        {
            return _impl.GetSchoolWithNotSub(term);
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsBySchoolId(string term, string schoolId)
        {
            return _impl.CreateSubscriptionsBySchoolId(term, schoolId);
        }

        public ResponseView SubmitSubscriptions(string booksellerId, string spareCount, IEnumerable<SubscriptionForSubmitView> subscriptions)
        {
            return _impl.SubmitSubscriptions(booksellerId, spareCount, subscriptions);
        }


        public IEnumerable<string> GetPressWithNotSub(string term)
        {
            return _impl.GetPressWithNotSub(term);
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionsByPress(string term, string press)
        {
            return _impl.CreateSubscriptionsByPress(term, press);
        }

        public IEnumerable<FeedbackStateView> GetFeedbackState()
        {
            return _impl.GetFeedbackState();
        }

        public IEnumerable<SubscriptionForSubmitView> GetSubscriptions(string term, FeedbackStateView state)
        {
            return _impl.GetSubscriptions(term, state);
        }

        public ResponseView RemoveSubscriptions(IEnumerable<SubscriptionForSubmitView> subscriptions)
        {
            return _impl.RemoveSubscriptions(subscriptions);
        }
    }
}
