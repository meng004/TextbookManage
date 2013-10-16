using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 实发教材查询
    /// </summary>
    [ServiceContract]
    public interface IReleaseTextbookForQueryAppl
    {
        /// <summary>
        /// 取学年学期
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TermView> GetTerm();

        /// <summary>
        /// 根据登录名取学院
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<SchoolView> GetSchoolByloginName(string loginName);

        /// <summary>
        /// 取年级
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<string> GetGradeBySchoolId(string schoolId);

        /// <summary>
        /// 根据班级从教学任务中取课程
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classNum"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<CourseView> GetCourseByClassNum(string classNum);

        /// <summary>
        /// 根据登录名取书商
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<BooksellerView> GetBooksellerByloginName(string loginName);

        /// <summary>
        /// 根据学院、年级取专业班级
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<ProfessionalClassView> GetClassBySchoolIdAndGrade(string schoolId, string grade);

        /// <summary>
        /// 根据专业班级取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<StudentView> GetStudentByProfessionalClassId(string classId);

        /// <summary>
        /// 根据学年学期，学生取学生实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<StudentReleaseDetailView> GetStudentReleaseDetail(string term, string studentNum);

        /// <summary>
        /// 根据学年学期，专业班级取班级实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<ClassReleaseDetailView> GetClassReleaseDetail(string term, string classId);

        /// <summary>
        /// 根据学年学期，书商取书商实发教材
        /// </summary>
        /// <param name="term"></param>
        /// <param name="booksellerId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<BooksellerReleaseDetailView> GetBooksellerReleaseDetail(string term, string booksellerId);
    }
}
