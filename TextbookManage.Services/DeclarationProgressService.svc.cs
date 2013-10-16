using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeclarationProgressService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeclarationProgressService.svc 或 DeclarationProgressService.svc.cs，然后开始调试。
    public class DeclarationProgressService : IDeclarationProgressAppl
    {
        private readonly IDeclarationProgressAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationProgressAppl>();



        public IEnumerable<DataSignView> GetDataSign()
        {
            return _impl.GetDataSign();
        }

        public IEnumerable<SchoolProgressView> GetSchoolProgress(string dataSignId)
        {
            return _impl.GetSchoolProgress(dataSignId);
        }

       public IEnumerable<DepartmentView> GetDepartments(string schoolId)
        {
            return _impl.GetDepartments(schoolId);
        }

        public IEnumerable<DepartmentProgressView> GetDepartmentProgress(string dataSignId, string departmentId)
        {
            return _impl.GetDepartmentProgress(dataSignId, departmentId);
        }


 
    }
}
