using System.Collections.Generic;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.IApplications;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“TextbookApprovalService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 TextbookApprovalService.svc 或 TextbookApprovalService.svc.cs，然后开始调试。
    public class TextbookApprovalService : ITextbookApprovalAppl
    {
        private readonly ITextbookApprovalAppl _impl = ServiceLocator.Current.GetInstance<ITextbookApprovalAppl>();

        public string GetAuditor(string loginName)
        {
            return _impl.GetAuditor(loginName);
        }

        public IEnumerable<ViewModels.SchoolView> GetSchoolWithNotApproval(string loginName)
        {
            return _impl.GetSchoolWithNotApproval(loginName);
        }
        
        public IEnumerable<ViewModels.TextbookForQueryView> GetTextbookWithNotApproval(string loginName, string schoolId)
        {
            return _impl.GetTextbookWithNotApproval(loginName, schoolId);
        }

        public ViewModels.ResponseView SubmitTextbookApproval(IEnumerable<ViewModels.TextbookForQueryView> textbook, string loginName, string suggestion, string remark)
        {
            return _impl.SubmitTextbookApproval(textbook, loginName, suggestion, remark);
        }
    }
}
