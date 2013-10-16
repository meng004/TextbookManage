using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 申报
    /// </summary>
    [ServiceContract]
    public interface IDeclarationAppl
    {

        /// <summary>
        /// 由登录用户名，取学院
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<SchoolView> GetSchoolByLoginName(string loginName);


        /// <summary>
        /// 由登录名、学院ID，取教研室
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DepartmentView> GetDepartmentByLoginName(string loginName, string schoolId);

        /// <summary>
        /// 由系教研室ID与学期，取课程
        /// 若学期为empty，则取当前学期
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<CourseView> GetCourseByDepartmentId(string departmentId);

        /// <summary>
        /// 由系教研室ID，课程ID，学年学期
        /// 取教学任务
        /// 如果学期为null，则取当前学期
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="courseId"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TeachingTaskView> GetTeachingTaskByDepartmentId(string departmentId, string courseId);

        /// <summary>
        /// 由教材名称、ISBN，取教材
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TextbookForDeclarationView> GetTextbooksByName(string name, string isbn);

        /// <summary>
        /// 提交学生用书申报
        /// </summary>
        /// <param name="teachingTaskNum"></param>
        /// <param name="textbookId"></param>
        /// <param name="teacherId"></param>
        /// <param name="mobile"></param>
        /// <param name="telephone"></param>
        /// <param name="declarationCount"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]        
        ResponseView SubmitStudentDeclaration(DeclarationView view);


        /// <summary>
        /// 提交教师用书申报
        /// </summary>
        /// <param name="teachingTaskNum"></param>
        /// <param name="textbookId"></param>
        /// <param name="teacherId"></param>
        /// <param name="mobile"></param>
        /// <param name="telephone"></param>
        /// <param name="declarationCount"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Remove)]   
        ResponseView SubmitTeacherDeclaration(DeclarationView view);

        /// <summary>
        /// 由教学班编号，取专业班
        /// </summary>
        /// <param name="teachingTaskNum"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<ProfessionalClassView> GetProfessionalClassByTeachingTaskNum(string teachingTaskNum);

        /// <summary>
        /// 由教学班编号，取已有申报
        /// </summary>
        /// <param name="teachingTaskNum"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DeclarationForTeachingTaskView> GetDeclarationByTeacingTaskNum(string teachingTaskNum);

        /// <summary>
        /// 计算学生人数
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        [OperationContract]
        string CalculateDeclarationCount(IEnumerable<TeachingTaskView> views);
    }
}
