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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“TextbookFeeService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 TextbookFeeService.svc 或 TextbookFeeService.svc.cs，然后开始调试。
    public class TextbookFeeService : ITextbookFeeAppl
    {
        private readonly ITextbookFeeAppl _impl = ServiceLocator.Current.GetInstance<ITextbookFeeAppl>();

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
        /// 根据登录名取书商
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public IEnumerable<BooksellerView> GetBooksellerByloginName(string loginName)
        {
            return _impl.GetBooksellerByloginName(loginName);
        }

        /// <summary>
        /// 根据专业班级取课程
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<CourseView> GetCourseByClassId(string classId)
        {
            return _impl.GetCourseByClassId(classId);
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
        /// 根据专业班级取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<StudentView> GetStudentByProfessionalClassId(string classId)
        {
            return _impl.GetStudentByProfessionalClassId(classId);
        }

        /// <summary>
        /// 根据学年学期，班级取班级教材费用
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<TextbookFeeForProfessionalClassView> GetProfessionalClassFee(string term, string classId)
        {
            return _impl.GetProfessionalClassFee(term, classId);
        }

        /// <summary>
        /// 根据学年学期，学生姓名取学生个人教材费用
        /// </summary>
        /// <param name="term"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public IEnumerable<TextbookFeeForStudentView> GetStudentFee(string term, string studentName)
        {
            return _impl.GetStudentFee(term, studentName);
        }

        /// <summary>
        /// 根据学年学期，书商，专业班级取书商班级教材费用
        /// </summary>
        /// <param name="term"></param>
        /// <param name="booksellerId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public IEnumerable<TextbookFeeForBooksellerProfessionClassView> GetBooksellerProfessionalClassFee(string term, string booksellerId, string classId)
        {
            return _impl.GetBooksellerProfessionalClassFee(term, booksellerId, classId);
        }
    }
}
