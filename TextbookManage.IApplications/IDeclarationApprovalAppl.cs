using System.Collections.Generic;
using System.ServiceModel;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 申报审核
    /// </summary>
    [ServiceContract]
    public interface IDeclarationApprovalAppl
    {

        /// <summary>
        /// 由登录名，获取当前登录用户姓名
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetAuditor(string loginName);

        /// <summary>
        /// 由登录名，取待审学院
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<SchoolView> GetSchoolWithNotApproval(string loginName);

        /// <summary>
        /// 由登录名，学院ID，取待审申报
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<DeclarationForApprovalView> GetDeclarationWithNotApproval(string loginName,string schoolId);

        /// <summary>
        /// 提交用书申报审核
        /// </summary>
        /// <param name="declarations"></param>
        /// <param name="auditor"></param>
        /// <param name="division"></param>
        /// <param name="suggestion"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseView SubmitDeclarationApproval(IEnumerable<DeclarationForApprovalView> declarations, string loginName, string suggestion, string remark);

    }
}
