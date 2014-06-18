using System.Collections.Generic;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeclarationQueryService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeclarationQueryService.svc 或 DeclarationQueryService.svc.cs，然后开始调试。
    public class DeclarationQueryService : IDeclarationQueryAppl
    {

        private readonly IDeclarationQueryAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationQueryAppl>();

        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            return _impl.GetSchoolByLoginName(loginName);
        }

        public IEnumerable<DepartmentView> GetDepartmentBySchoolId(string loginName, string schoolId)
        {
            return _impl.GetDepartmentBySchoolId(loginName, schoolId);
        }

        public IEnumerable<TermView> GetTerm()
        {
            return _impl.GetTerm();
        }

        public IEnumerable<RecipientTypeView> GetRecipientType()
        {
            return _impl.GetRecipientType();
        }

        public IEnumerable<CourseView> GetCourseByDepartmentId(string departmentId, string term)
        {
            return _impl.GetCourseByDepartmentId(departmentId, term);
        }

        public IEnumerable<DeclarationForQueryView> GetDeclarationByCourseId(string courseId, string departmentId, string term, string recipientTypeName)
        {
            return _impl.GetDeclarationByCourseId(courseId, departmentId, term, recipientTypeName);
        }

        public IEnumerable<ApprovalView> GetDeclarationApproval(string declarationId)
        {
            return _impl.GetDeclarationApproval(declarationId);
        }

        public FeedbackView GetFeedbackByStudentDeclarationId(string declarationId)
        {
            return _impl.GetFeedbackByStudentDeclarationId(declarationId);
        }

        public FeedbackView GetFeedbackByTeacherDeclarationId(string declarationId)
        {
            return _impl.GetFeedbackByTeacherDeclarationId(declarationId);
        }
    }
}
