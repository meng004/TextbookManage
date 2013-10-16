using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TextbookManage.IApplications;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.ViewModels;

namespace TextbookManage.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ReleaseTextbookForQueryServiec”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ReleaseTextbookForQueryServiec.svc 或 ReleaseTextbookForQueryServiec.svc.cs，然后开始调试。
    public class ReleaseTextbookForQueryServiec : IReleaseTextbookForQueryAppl
    {
        private readonly IReleaseTextbookForQueryAppl _impl = ServiceLocator.Current.GetInstance<IReleaseTextbookForQueryAppl>();

        /// <summary>
        /// 取学年学期
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TermView> GetTerm()
        {
            return _impl.GetTerm();
        }

        /// <summary>
        /// 根据登录名取学院
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<SchoolView> GetSchoolByloginName(string loginName)
        {
            return _impl.GetSchoolByloginName(loginName);
        }

        /// <summary>
        /// 根据学院取年级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetGradeBySchoolId(string schoolId)
        {
            return _impl.GetGradeBySchoolId(schoolId);
        }

        /// <summary>
        /// 根据班级取课程
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<CourseView> GetCourseByClassNum(string classNum)
        {
            return _impl.GetCourseByClassNum(classNum);
        }

        /// <summary>
        /// 根据登录名取书商
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<BooksellerView> GetBooksellerByloginName(string loginName)
        {
            return _impl.GetBooksellerByloginName(loginName);
        }

        /// <summary>
        /// 根据学院，年级取班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public IEnumerable<ProfessionalClassView> GetClassBySchoolIdAndGrade(string schoolId, string grade)
        {
            return _impl.GetClassBySchoolIdAndGrade(schoolId, grade);
        }

        /// <summary>
        /// 根据班级取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<StudentView> GetStudentByProfessionalClassId(string classId)
        {
            return _impl.GetStudentByProfessionalClassId(classId);
        }

        /// <summary>
        /// 根据学年学期，学生取学生实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public IEnumerable<StudentReleaseDetailView> GetStudentReleaseDetail(string term, string studentId)
        {
            return _impl.GetStudentReleaseDetail(term, studentId);
        }

        /// <summary>
        /// 根据学年学期，班级取班级实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<ClassReleaseDetailView> GetClassReleaseDetail(string term, string classId)
        {
            return _impl.GetClassReleaseDetail(term, classId);
        }

        /// <summary>
        /// 根据学年学期，书商取书商实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        public IEnumerable<BooksellerReleaseDetailView> GetBooksellerReleaseDetail(string term, string booksellerId)
        {
            return _impl.GetBooksellerReleaseDetail(term, booksellerId);
        }
    }
}
