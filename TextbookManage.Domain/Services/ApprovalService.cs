using System;
using TextbookManage.Domain.Models;

namespace TextbookManage.Domain
{
    public class ApprovalService
    {

        #region 创建审核

        /// <summary>
        /// 创建审核记录
        /// </summary>
        /// <param name="declaration">待审核对象，教材、回告、申报等</param>
        /// <param name="approvalDivision">审核部门</param>
        /// <param name="approvalPerson">审核人</param>
        /// <param name="approvalSuggestion">审核意见，同意或不同意</param>
        /// <param name="remark">审核说明</param>
        /// <typeparam name="T">审核记录类型，如：教材审核、回告审核、用书申报审核等</typeparam>
        public static void CreateApproval<T>(dynamic declaration, string approvalDivision, string approvalPerson, bool approvalSuggestion, string remark) 
            where T : Approval, new()
        {
            //创建用书审核
            var approval = new T
            {
                ApprovalDate = DateTime.Now,
                Division = approvalDivision,
                Auditor = approvalPerson,
                Suggestion = approvalSuggestion,
                Remark = remark
            };
            //修改审核状态
            declaration.Approval(approvalSuggestion);
            //添加审核
            declaration.Approvals.Add(approval);            
        }
        #endregion
    }
}
