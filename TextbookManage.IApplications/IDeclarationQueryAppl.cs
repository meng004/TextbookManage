using System.Collections.Generic;
using TextbookManage.ViewModels;
using System.ServiceModel;
using TextbookManage.Infrastructure.Cache;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 申报查询
    /// </summary>    
    [ServiceContract]
    public interface IDeclarationQueryAppl
    {

        /// <summary>
        /// 由登录名，取学院
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
        IEnumerable<DepartmentView> GetDepartmentBySchoolId(string loginName, string schoolId);


        /// <summary>
        /// 取学年学期
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<TermView> GetTerm();


        /// <summary>
        /// 取领用人类型
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<RecipientTypeView> GetRecipientType();

        /// <summary>
        /// 由系教研室ID与学期，取课程
        /// 若学期为empty，则取当前学期
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<CourseView> GetCourseByDepartmentId(string departmentId, string term);


        /// <summary>
        /// 由课程ID，系教研室ID，学年学期，领用人类型
        /// 取申报
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="term"></param>
        /// <param name="recipientType"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<DeclarationForQueryView> GetDeclarationByCourseId(string courseId, string departmentId, string term, string recipientTypeName);

        /// <summary>
        /// 由申报ID，取审核记录
        /// </summary>
        /// <param name="declarationId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        IEnumerable<ApprovalView> GetDeclarationApproval(string declarationId);

        /// <summary>
        /// 由申报ID，取回告
        /// </summary>
        /// <param name="declarationId"></param>
        /// <returns></returns>
        [OperationContract]
        [Cache(CacheMethod.Get)]
        FeedbackView GetFeedbackByDeclarationId(string declarationId);
    }
}
