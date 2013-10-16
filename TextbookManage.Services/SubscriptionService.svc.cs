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


        public IEnumerable<BooksellerView> GetBookseller()
        {
            return _impl.GetBookseller();
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionByTextbook(string textbookName, string isbn)
        {
            return _impl.CreateSubscriptionByTextbook(textbookName, isbn);
        }

        public IEnumerable<SchoolView> GetSchoolWithNotSub()
        {
            return _impl.GetSchoolWithNotSub();
        }

        public IEnumerable<SubscriptionForSubmitView> CreateSubscriptionBySchoolId(string schoolId)
        {
            return _impl.CreateSubscriptionBySchoolId(schoolId);
        }

        public ResponseView SubmitSubscription(IEnumerable<SubscriptionForSubmitView> subscriptions, string booksellerId, string spareCount)
        {
            return _impl.SubmitSubscription(subscriptions, booksellerId, spareCount);
        }
    }
}
