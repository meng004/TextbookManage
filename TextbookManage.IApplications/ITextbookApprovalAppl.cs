using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    /// <summary>
    /// 教材审核
    /// </summary>
    [ServiceContract]
    public interface ITextbookApprovalAppl
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
        /// 由登录名，学院ID，取待审教材申报
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TextbookForQueryView> GetTextbookWithNotApproval(string loginName, string schoolId);

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
        ResponseView SubmitTextbookApproval(IEnumerable<TextbookForQueryView> textbook, string loginName, string suggestion, string remark);

    }
}
