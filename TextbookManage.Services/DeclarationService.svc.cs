using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;


namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeclarationService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeclarationService.svc 或 DeclarationService.svc.cs，然后开始调试。
    public class DeclarationService : IDeclarationAppl
    {

        private readonly IDeclarationAppl _impl = ServiceLocator.Current.GetInstance<IDeclarationAppl>();


        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            return _impl.GetSchoolByLoginName(loginName);
        }

        public IEnumerable<DepartmentView> GetDepartmentByLoginName(string loginName, string schoolId)
        {
            return _impl.GetDepartmentByLoginName(loginName, schoolId);
        }

        public IEnumerable<CourseView> GetCourseByDepartmentId(string departmentId)
        {
            return _impl.GetCourseByDepartmentId(departmentId);
        }

        public IEnumerable<TeachingTaskView> GetTeachingTaskByDepartmentId(string departmentId, string courseId)
        {
            return _impl.GetTeachingTaskByDepartmentId(departmentId, courseId);
        }

        public IEnumerable<TextbookForDeclarationView> GetTextbooksByName(string name, string isbn)
        {
            return _impl.GetTextbooksByName(name, isbn);
        }

        public ResponseView SubmitStudentDeclaration(DeclarationView view)
        {
            return _impl.SubmitStudentDeclaration(view);
        }

        public ResponseView SubmitTeacherDeclaration(DeclarationView view)
        {
            return _impl.SubmitTeacherDeclaration(view);
        }

        public IEnumerable<ProfessionalClassView> GetProfessionalClassByTeachingTaskNum(string teachingTaskNum)
        {
            return _impl.GetProfessionalClassByTeachingTaskNum(teachingTaskNum);
        }

        public IEnumerable<DeclarationForTeachingTaskView> GetDeclarationByTeacingTaskNum(string teachingTaskNum)
        {
            return _impl.GetDeclarationByTeacingTaskNum(teachingTaskNum);
        }

        public string CalculateDeclarationCount(IEnumerable<TeachingTaskView> views)
        {
            return _impl.CalculateDeclarationCount(views);
        }
    }
}
