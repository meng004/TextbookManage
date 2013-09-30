using System.Collections.Generic;
using TextbookManage.ViewModels;

namespace TextbookManage.IApplications
{
    public interface IApprovalDeclaration : ISchool
    {

        /// <summary>
        /// 获取审核人姓名
        /// </summary>
        /// <returns></returns>
        string GetApprovalPerson();

        /// <summary>
        /// 根据学院ID，获取待审核用书申报列表
        /// </summary>
        /// <param name="schoolId">学院ID</param>
        /// <returns></returns>
        IEnumerable<ApprovalView> GetDeclarationList(string schoolId);

        /// <summary>
        /// 根据用书申报列表、审核意见、备注，提交用书申报审核
        /// </summary>
        /// <param name="declarationIds">用书申报列表</param>
        /// <param name="approvalSuggestion">审核意见，同意或不同意</param>
        /// <param name="remark">备注，说明</param>
        /// <returns></returns>
        void SubmitApprovalDeclarations(IEnumerable<ApprovalView> declarationViews, string approvalSuggestion, string remark, ref string message);

    }
}
