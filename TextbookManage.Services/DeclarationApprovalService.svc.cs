using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeclarationApprovalService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeclarationApprovalService.svc 或 DeclarationApprovalService.svc.cs，然后开始调试。
    public class DeclarationApprovalService : IDeclarationApprovalAppl
    {
        private readonly IDeclarationApprovalAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationApprovalAppl>();


        public string GetAuditor(string loginName)
        {
            return _impl.GetAuditor(loginName);
        }

        public IEnumerable<ViewModels.SchoolView> GetSchoolWithNotApproval(string loginName)
        {
            return _impl.GetSchoolWithNotApproval(loginName);
        }

        public IEnumerable<ViewModels.DeclarationForApprovalView> GetDeclarationWithNotApproval(string loginName, string schoolId)
        {
            return _impl.GetDeclarationWithNotApproval(loginName, schoolId);
        }

        public ViewModels.ResponseView SubmitDeclarationApproval(IEnumerable<ViewModels.DeclarationForApprovalView> declarations, string loginName, string suggestion, string remark)
        {
            return _impl.SubmitDeclarationApproval(declarations, loginName, suggestion, remark);
        }
    }
}
