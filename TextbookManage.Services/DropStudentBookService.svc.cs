using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Infrastructure.ServiceLocators;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DropStudentBookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DropStudentBookService.svc 或 DropStudentBookService.svc.cs，然后开始调试。
    public class DropStudentBookService : IDropStudentBookAppl
    {

        private readonly IDropStudentBookAppl _impl = ServiceLocator.Current.GetInstance<IDropStudentBookAppl>();

        /// <summary>
        ///  根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByLoginName(string loginName)
        {
            return _impl.GetSchoolByLoginName(loginName);
        }
        /// <summary>
        /// 取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            return _impl.GetGradeBySchoolId(schoolId);
        }
        /// <summary>
        /// 根据学院Id、年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public IEnumerable<ProfessionalClassView> GetClassBySchoolId(string schoolId, string grade)
        {
            return _impl.GetClassBySchoolId(schoolId, grade);
        }
        /// <summary>
        /// 根据班级Id,取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.StudentView> GetStudentByClassId(string classId)
        {
            return _impl.GetStudentByClassId(classId);
        }
        /// <summary>
        /// 根据学生ID，取学生个人可退还教材
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public IEnumerable<ViewModels.DropBookForStudentQueryView> GetStudentDropBookByStudentId(string studentId)
        {
            return _impl.GetStudentDropBookByStudentId(studentId);
        }
        /// <summary>
        /// 根据书商Id，发放记录Id，退还学生个人教材
        /// </summary>
        /// <param name="releaseRecordeIds"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public ViewModels.ResponseView DropStudenBookSubmit(IEnumerable<string> releaseRecordeIds, string studentId)
        {
            return _impl.DropStudenBookSubmit(releaseRecordeIds, studentId);
        }
    }
}
